window.blazorChartInterop = {
    canvasExists: function (canvasId) {
        return document.getElementById(canvasId) !== null;
    },

    loadChartJs: function () {
        return new Promise((resolve, reject) => {
            if (typeof Chart !== 'undefined') {
                resolve();
            } else {
                const script = document.createElement('script');
                script.src = 'https://cdn.jsdelivr.net/npm/chart.js';
                script.onload = resolve;
                script.onerror = reject;
                document.head.appendChild(script);
            }
        });
    },

    renderGauge: async function (canvasId, value, max) {
        await this.loadChartJs();
        var ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (window[canvasId + '_instance']) window[canvasId + '_instance'].destroy();

        window[canvasId + '_instance'] = new Chart(ctx, {
            type: 'doughnut',
            data: {
                datasets: [{
                    data: [value, max - value],
                    backgroundColor: ['#7c3aed', '#f1f5f9'],
                    borderWidth: 0,
                    circumference: 180,
                    rotation: 270,
                    borderRadius: 10
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                cutout: '85%',
                plugins: {
                    legend: { display: false },
                    tooltip: { enabled: false }
                }
            }
        });
    },

    renderBarChart: async function (canvasId, labels, data) {
        await this.loadChartJs();
        var ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (window[canvasId + '_instance']) window[canvasId + '_instance'].destroy();

        window[canvasId + '_instance'] = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    backgroundColor: '#8b5cf6',
                    borderRadius: { topLeft: 6, topRight: 6, bottomLeft: 0, bottomRight: 0 },
                    barPercentage: 0.6,
                    borderWidth: 0
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        backgroundColor: '#fff',
                        titleColor: '#1e293b',
                        bodyColor: '#1e293b',
                        borderColor: '#e2e8f0',
                        borderWidth: 1,
                        padding: 10,
                        displayColors: false,
                        callbacks: {
                            label: function (context) {
                                return '₹' + context.parsed.y.toLocaleString();
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        grid: { display: false },
                        border: { display: false },
                        ticks: { display: false } // Hide bottom labels to match design exactly
                    },
                    y: {
                        grid: { color: '#f1f5f9', borderDash: [4, 4] },
                        border: { display: false },
                        ticks: { color: '#94a3b8', font: { size: 10 }, stepSize: 50000 }
                    }
                }
            }
        });
    },

    renderSmoothLine: async function (canvasId, labels, data) {
        await this.loadChartJs();
        var ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (window[canvasId + '_instance']) window[canvasId + '_instance'].destroy();

        window[canvasId + '_instance'] = new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Amount Collected',
                    data: data,
                    backgroundColor: 'rgba(139, 92, 246, 0.1)',
                    borderColor: '#8b5cf6',
                    borderWidth: 2,
                    pointBackgroundColor: '#fff',
                    pointBorderColor: '#8b5cf6',
                    pointBorderWidth: 2,
                    pointRadius: 0,
                    pointHoverRadius: 6,
                    fill: true,
                    tension: 0.4 // Smooth bezier curve
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                interaction: {
                    mode: 'index',
                    intersect: false,
                },
                plugins: {
                    legend: { display: false },
                    tooltip: {
                        backgroundColor: 'rgba(255, 255, 255, 0.95)',
                        titleColor: '#0f172a',
                        titleFont: { family: "'Inter', sans-serif", size: 13 },
                        bodyColor: '#334155',
                        bodyFont: { family: "'Inter', sans-serif", size: 12 },
                        borderColor: '#e2e8f0',
                        borderWidth: 1,
                        padding: 12,
                        boxPadding: 6,
                        usePointStyle: true,
                        callbacks: {
                            label: function (context) {
                                return ' ' + context.dataset.label + ': \u20B9' + context.parsed.y.toLocaleString();
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        grid: { color: '#f1f5f9' },
                        border: { display: false },
                        ticks: { display: false }
                    },
                    y: {
                        grid: { color: '#f1f5f9', borderDash: [4, 4] },
                        border: { display: false },
                        ticks: { color: '#94a3b8', font: { size: 10 }, stepSize: 50000 }
                    }
                }
            }
        });
    },

    // --- NEW HOSPITAL ANALYTICS CHARTS ---

    renderHospitalDoughnut: async function (canvasId, labels, data) {
        await this.loadChartJs();
        var ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (window[canvasId + '_instance']) window[canvasId + '_instance'].destroy();

        const colors = ['#6366f1', '#f43f5e', '#8b5cf6', '#14b8a6', '#f59e0b', '#0ea5e9'];

        window[canvasId + '_instance'] = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    backgroundColor: colors,
                    borderWidth: 0,
                    hoverOffset: 6
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                cutout: '70%',
                plugins: {
                    legend: {
                        position: 'right',
                        labels: {
                            usePointStyle: true,
                            padding: 20,
                            font: { family: "'Inter', sans-serif", size: 12, weight: '500' },
                            color: '#475569'
                        }
                    },
                    tooltip: {
                        backgroundColor: 'rgba(15, 23, 42, 0.9)',
                        titleFont: { family: "'Inter', sans-serif", size: 13 },
                        bodyFont: { family: "'Inter', sans-serif", size: 12 },
                        padding: 12,
                        cornerRadius: 8,
                        displayColors: true,
                        callbacks: {
                            label: function (context) {
                                return ' ' + context.label + ': ' + context.parsed + ' patients';
                            }
                        }
                    }
                }
            }
        });
    },

    renderHospitalBar: async function (canvasId, labels, revenueData, collectedData) {
        await this.loadChartJs();
        var ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (window[canvasId + '_instance']) window[canvasId + '_instance'].destroy();

        window[canvasId + '_instance'] = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [
                    {
                        label: 'Total Revenue',
                        data: revenueData,
                        backgroundColor: '#e2e8f0',
                        borderRadius: 6,
                        barPercentage: 0.6,
                        categoryPercentage: 0.8
                    },
                    {
                        label: 'Collected Amount',
                        data: collectedData,
                        backgroundColor: '#6366f1',
                        borderRadius: 6,
                        barPercentage: 0.6,
                        categoryPercentage: 0.8
                    }
                ]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                interaction: {
                    mode: 'index',
                    intersect: false,
                },
                plugins: {
                    legend: {
                        position: 'top',
                        align: 'end',
                        labels: {
                            usePointStyle: true,
                            boxWidth: 8,
                            font: { family: "'Inter', sans-serif", size: 12 },
                            color: '#64748b'
                        }
                    },
                    tooltip: {
                        backgroundColor: 'rgba(255, 255, 255, 0.95)',
                        titleColor: '#0f172a',
                        bodyColor: '#334155',
                        borderColor: '#e2e8f0',
                        borderWidth: 1,
                        padding: 12,
                        boxPadding: 4,
                        usePointStyle: true,
                        callbacks: {
                            label: function (context) {
                                return context.dataset.label + ': \\u20B9' + context.parsed.y.toLocaleString();
                            }
                        }
                    }
                },
                scales: {
                    x: {
                        grid: { display: false },
                        border: { display: false },
                        ticks: {
                            font: { family: "'Inter', sans-serif", size: 11 },
                            color: '#64748b'
                        }
                    },
                    y: {
                        grid: { color: '#f1f5f9', borderDash: [4, 4] },
                        border: { display: false },
                        ticks: {
                            font: { family: "'Inter', sans-serif", size: 11 },
                            color: '#94a3b8',
                            callback: function (value) {
                                if (value >= 1000) {
                                    return '\\u20B9' + (value / 1000) + 'k';
                                }
                                return '\\u20B9' + value;
                            }
                        }
                    }
                }
            }
        });
    }
};
