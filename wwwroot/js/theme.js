// LIMS Theme Manager — Dark / Light Mode Toggle
(function () {
    'use strict';

    const THEME_KEY = 'lims-theme';
    const DARK = 'dark';
    const LIGHT = 'light';

    /** Apply the theme by setting the data-theme attribute on <html> */
    function applyTheme(theme) {
        document.documentElement.setAttribute('data-theme', theme);
        updateToggleIcon(theme);
    }

    /** Update the button icon */
    function updateToggleIcon(theme) {
        const btn = document.getElementById('dark-mode-toggle');
        if (!btn) return;
        btn.innerHTML = theme === DARK
            ? '<i class="fas fa-sun"></i>'
            : '<i class="fas fa-moon"></i>';
        btn.title = theme === DARK ? 'Switch to Light Mode' : 'Switch to Dark Mode';
    }

    /** Toggle between dark and light */
    function toggleTheme() {
        const current = document.documentElement.getAttribute('data-theme') || LIGHT;
        const next = current === DARK ? LIGHT : DARK;
        sessionStorage.setItem(THEME_KEY, next);
        applyTheme(next);
    }

    /** Ensure the correct theme is applied (e.g. after navigation) */
    function syncTheme() {
        const saved = sessionStorage.getItem(THEME_KEY) || LIGHT;
        applyTheme(saved);
        
        const btn = document.getElementById('dark-mode-toggle');
        if (btn) {
            btn.onclick = toggleTheme;
            updateToggleIcon(saved);
        }
    }

    /** Initialize on page load */
    function init() {
        syncTheme();

        // Attach click handler (button may be added later by Blazor, so also expose globally)
        const btn = document.getElementById('dark-mode-toggle');
        if (btn) btn.addEventListener('click', toggleTheme);
    }

    // Expose for Blazor JS interop
    window.limsTheme = {
        toggle: toggleTheme,
        apply: applyTheme,
        sync: syncTheme,
        getCurrent: function () {
            return document.documentElement.getAttribute('data-theme') || LIGHT;
        }
    };

    // Re-run full init after DOM is ready
    if (document.readyState === 'loading') {
        document.addEventListener('DOMContentLoaded', init);
    } else {
        init();
    }

    // Blazor .NET 8 Enhanced Navigation support
    // This event fires after Blazor patches the DOM during an enhanced navigation
    document.addEventListener('blazor:afterUpdate', syncTheme);
    
    // Support for .NET 8 Enhanced Navigation via Blazor.addEventListener
    function attachBlazorEvents() {
        if (window.Blazor) {
            window.Blazor.addEventListener('enhancedload', syncTheme);
        } else {
            // If Blazor is not yet initialized, try again shortly
            setTimeout(attachBlazorEvents, 100);
        }
    }
    attachBlazorEvents();

    // Some versions of Blazor use different events or we might need to catch the enhanced load
    window.addEventListener('popstate', syncTheme);
    
    // MutationObserver to ensure data-theme stays put if Blazor tries to reset the <html> tag
    const observer = new MutationObserver(function() {
        const saved = sessionStorage.getItem(THEME_KEY) || LIGHT;
        if (document.documentElement.getAttribute('data-theme') !== saved) {
            document.documentElement.setAttribute('data-theme', saved);
        }
    });
    observer.observe(document.documentElement, { attributes: true, attributeFilter: ['data-theme'] });

})();
