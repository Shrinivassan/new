// Sidebar Toggle Functionality
document.addEventListener('DOMContentLoaded', function() {
    const sidebar = document.getElementById('sidebar');
    const mainContent = document.getElementById('main-content');
    
    // Create toggle button
    const toggleBtn = document.createElement('button');
    toggleBtn.className = 'sidebar-toggle-btn';
    toggleBtn.innerHTML = '<i class="fas fa-chevron-left"></i>';
    toggleBtn.setAttribute('aria-label', 'Toggle Sidebar');
    
    // Add toggle button to sidebar
    if (sidebar) {
        sidebar.style.position = 'relative';
        sidebar.appendChild(toggleBtn);
    }
    
    // Toggle sidebar on button click
    toggleBtn.addEventListener('click', function() {
        sidebar.classList.toggle('collapsed');
        mainContent.classList.toggle('expanded');
        
        // Update icon direction
        const icon = toggleBtn.querySelector('i');
        if (sidebar.classList.contains('collapsed')) {
            icon.classList.remove('fa-chevron-left');
            icon.classList.add('fa-chevron-right');
        } else {
            icon.classList.remove('fa-chevron-right');
            icon.classList.add('fa-chevron-left');
        }
        
        // Save state to localStorage
        const isCollapsed = sidebar.classList.contains('collapsed');
        localStorage.setItem('sidebarCollapsed', isCollapsed);
    });
    
    // Restore saved state
    const savedState = localStorage.getItem('sidebarCollapsed');
    if (savedState === 'true') {
        sidebar.classList.add('collapsed');
        mainContent.classList.add('expanded');
        const icon = toggleBtn.querySelector('i');
        icon.classList.remove('fa-chevron-left');
        icon.classList.add('fa-chevron-right');
    }
    
    // Mobile menu functionality (existing code compatibility)
    const mobileToggle = document.getElementById('mobile-toggle-btn');
    const mobileOverlay = document.getElementById('mobile-overlay');
    
    if (mobileToggle) {
        mobileToggle.addEventListener('click', function() {
            sidebar.classList.toggle('mobile-open');
            mobileOverlay.classList.toggle('active');
        });
    }
    
    if (mobileOverlay) {
        mobileOverlay.addEventListener('click', function() {
            sidebar.classList.remove('mobile-open');
            mobileOverlay.classList.remove('active');
        });
    }
});

// Additional CSS for mobile overlay
const style = document.createElement('style');
style.textContent = `
    .mobile-overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, 0.5);
        opacity: 0;
        visibility: hidden;
        transition: opacity 0.3s ease, visibility 0.3s ease;
        z-index: 35;
    }
    
    .mobile-overlay.active {
        opacity: 1;
        visibility: visible;
    }
`;
document.head.appendChild(style);