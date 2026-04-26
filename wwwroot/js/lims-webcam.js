window.limsWebcam = {
    stream: null,

    startWebcam: async function (videoId, canvasId) {
        try {
            if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
                const videoElement = document.getElementById(videoId);
                if (!videoElement) {
                    console.error('Video element not found:', videoId);
                    return;
                }

                this.stream = await navigator.mediaDevices.getUserMedia({ video: true });
                videoElement.srcObject = this.stream;
                // Try to play the video and wait for metadata so dimensions are available
                try {
                    const playPromise = videoElement.play();
                    if (playPromise && typeof playPromise.then === 'function') {
                        await playPromise;
                    }
                } catch (playError) {
                    // Autoplay policies may prevent play() until user gesture; still continue
                    console.warn('Video play() rejected (autoplay policy?):', playError);
                }
                // Ensure metadata loaded (gives videoWidth/videoHeight)
                if (videoElement.readyState < 2) {
                    await new Promise(resolve => {
                        const onLoaded = () => {
                            videoElement.removeEventListener('loadedmetadata', onLoaded);
                            resolve();
                        };
                        videoElement.addEventListener('loadedmetadata', onLoaded);
                        // Fallback timeout in case event doesn't fire
                        setTimeout(resolve, 1000);
                    });
                }
            } else {
                console.error('getUserMedia is not supported in this browser.');
            }
        } catch (error) {
            console.error('Error starting webcam:', error);
        }
    },

    stopWebcam: function (videoId) {
        if (this.stream) {
            this.stream.getTracks().forEach(track => track.stop());
            const videoElement = document.getElementById(videoId);
            if (videoElement) {
                videoElement.srcObject = null;
            }
            this.stream = null;
        }
    },

    capturePhoto: async function (videoId, canvasId) {
        try {
            const videoElement = document.getElementById(videoId);
            const canvasElement = document.getElementById(canvasId);

            if (!videoElement) {
                const msg = `Video element not found: ${videoId}`;
                console.error(msg);
                throw msg;
            }

            if (!canvasElement) {
                const msg = `Canvas element not found: ${canvasId}`;
                console.error(msg);
                throw msg;
            }

            // Prefer video element's srcObject (more reliable than relying on `this` binding)
            const streamObj = videoElement && videoElement.srcObject ? videoElement.srcObject : this.stream;
            if (!streamObj) {
                const msg = 'No active webcam stream found.';
                console.error(msg);
                throw msg;
            }

            const context = canvasElement.getContext('2d');


            // Wait briefly for video dimensions to become available (some devices take time)
            const waitForVideoDimensions = (maxMs = 3000) => new Promise(res => { // Increased timeout to 3s
                const start = Date.now();
                const check = () => {
                    if (videoElement && videoElement.videoWidth > 0 && videoElement.videoHeight > 0) return res(true);
                    if (Date.now() - start > maxMs) return res(false);
                    requestAnimationFrame(check);
                };
                check();
            });

            // Use video intrinsic size when available, fall back to client size or defaults
            await waitForVideoDimensions(3000);
            let width = videoElement.videoWidth || videoElement.clientWidth || 640;
            let height = videoElement.videoHeight || videoElement.clientHeight || 480;

            // Scale down large images to reduce payload size (helps avoid SignalR message size limits)
            const maxWidth = 800; // reasonable default max width
            if (width > maxWidth) {
                const ratio = maxWidth / width;
                width = Math.round(width * ratio);
                height = Math.round(height * ratio);
            }

            canvasElement.width = width;
            canvasElement.height = height;

            // Draw the current video frame to the canvas
            context.drawImage(videoElement, 0, 0, width, height);

            // Return the image as a compressed JPEG data URL (smaller than PNG)
            // Use quality 0.7 to balance size/quality. Blazor will still receive a string result.
            const dataUrl = canvasElement.toDataURL('image/jpeg', 0.7);
            return dataUrl;
        } catch (error) {
            console.error('Error capturing photo:', error);
            throw (error && error.message ? error.message : error);
        }
    }
};