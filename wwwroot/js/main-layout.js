document.addEventListener('DOMContentLoaded', function () {
    const submenuToggles = document.querySelectorAll('.submenu-toggle');

    submenuToggles.forEach(toggle => {
        toggle.addEventListener('click', (e) => {
            const submenu = toggle.nextElementSibling;
            const container = toggle.closest('.has-submenu');
            if (submenu && submenu.classList.contains('submenu')) {
                const isOpen = submenu.style.display === 'block';
                if (isOpen) {
                    submenu.style.display = 'none';
                    toggle.setAttribute('aria-expanded', 'false');
                    if (container) container.classList.remove('open');
                } else {
                    submenu.style.display = 'block';
                    toggle.setAttribute('aria-expanded', 'true');
                    if (container) container.classList.add('open');
                }
            }
        });
    });

    // On load, ensure any submenu containing an active nav-link is opened
    document.querySelectorAll('.has-submenu').forEach(container => {
        const submenu = container.querySelector('.submenu');
        const toggle = container.querySelector('.submenu-toggle');
        if (!submenu || !toggle) return;
        // If any child link is active, open the submenu
        const activeChild = submenu.querySelector('.nav-link.active');
        if (activeChild) {
            submenu.style.display = 'block';
            toggle.setAttribute('aria-expanded', 'true');
            container.classList.add('open');
        }
    });

    // Initialize body-based tooltips for nav links that have `data-tooltip`.
    // Tooltips are appended to document.body so they won't be clipped by the sidebar
    // and will appear over the main content. They only show when the sidebar is collapsed.
    function initBodyTooltips() {
        let activeTooltip = null;
        let currentTarget = null;

        function showTooltip(target) {
            const sidebar = document.getElementById('sidebar');
            if (!sidebar || !sidebar.classList.contains('collapsed')) return;
            const text = target.getAttribute('data-tooltip');
            if (!text) return;
            hideTooltip();

            const tip = document.createElement('div');
            tip.className = 'body-tooltip';
            tip.textContent = text;
            // ensure tooltip does not intercept pointer events and is positioned fixed
            tip.style.position = 'fixed';
            tip.style.pointerEvents = 'none';
            tip.style.zIndex = '1002';
            document.body.appendChild(tip);
            activeTooltip = tip;
            currentTarget = target;
            positionTooltip();
            window.addEventListener('scroll', positionTooltip, true);
            window.addEventListener('resize', positionTooltip);
        }

        function positionTooltip() {
            if (!activeTooltip || !currentTarget) return;
            const rect = currentTarget.getBoundingClientRect();
            const tipRect = activeTooltip.getBoundingClientRect();
            // Place tooltip to the right of the icon, centered vertically
            let left = rect.right + 12; // 12px gap
            let top = rect.top + (rect.height - tipRect.height) / 2;

            // If there's not enough space on the right, place to the left
            if (left + tipRect.width > window.innerWidth - 8) {
                left = rect.left - tipRect.width - 12;
            }

            // Keep tooltip within viewport vertically
            if (top < 8) top = 8;
            if (top + tipRect.height > window.innerHeight - 8) top = window.innerHeight - tipRect.height - 8;

            activeTooltip.style.left = Math.round(left) + 'px';
            activeTooltip.style.top = Math.round(top) + 'px';
        }

        function hideTooltip() {
            if (activeTooltip) {
                activeTooltip.remove();
                activeTooltip = null;
                currentTarget = null;
                window.removeEventListener('scroll', positionTooltip, true);
                window.removeEventListener('resize', positionTooltip);
            }
        }

        // Attach handlers to all current and future nav-link[data-tooltip] elements
        function attachHandlers(root = document) {
            const nodes = root.querySelectorAll('.nav-link[data-tooltip]');
            nodes.forEach(node => {
                // avoid double-binding
                if (node.__hasBodyTooltip) return;
                node.__hasBodyTooltip = true;
                node.addEventListener('mouseenter', () => showTooltip(node));
                node.addEventListener('focus', () => showTooltip(node));
                node.addEventListener('mouseleave', hideTooltip);
                node.addEventListener('blur', hideTooltip);
            });
        }

        // initial attach
        attachHandlers();

        // observe for dynamically added nav-links
        const obs = new MutationObserver(mutations => {
            // simply re-run attachHandlers for the document when new nodes appear
            attachHandlers(document);
        });
        obs.observe(document.body, { childList: true, subtree: true });
    }

    initBodyTooltips();

    // sessionStorageManager: helper to reload the page once when a specific
    // sessionStorage key is present. Used to force a full page reload after
    // a client-side navigation (for example, immediately after login) so
    // server-provided data like the sidebar can initialize correctly.
    window.sessionStorageManager = {
        reloadOnFirstLoad: function (key) {
            try {
                var v = sessionStorage.getItem(key);
                if (v === '1') {
                    sessionStorage.removeItem(key);
                    // Force a full reload of the page
                    location.reload();
                }
            } catch (e) {
                console.error('sessionStorageManager.reloadOnFirstLoad error', e);
            }
        }
    };
});




window.dropdownHelper = {
    activeListeners: {},

    registerOutsideClick: function (dotNetHelper, dropdownId) {
        // remove old listener if exists
        if (this.activeListeners[dropdownId]) {
            document.removeEventListener("click", this.activeListeners[dropdownId]);
        }

        // define new listener
        const onClick = (event) => {
            const dropdown = document.getElementById(dropdownId);
            if (dropdown && !dropdown.contains(event.target)) {
                dotNetHelper.invokeMethodAsync("CloseDropdownById", dropdownId);
                document.removeEventListener("click", onClick);
                delete this.activeListeners[dropdownId];
            }
        };

        // slight delay to avoid closing instantly when opened
        setTimeout(() => document.addEventListener("click", onClick));
        this.activeListeners[dropdownId] = onClick;
    }
};
