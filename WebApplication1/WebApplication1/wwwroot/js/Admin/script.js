function toggleMenu(element) {
    const allMenus = document.querySelectorAll(".Title .Contain");
    const sidebarMenu = document.querySelector(".Dashboard .Sidebar");

    if (sidebarMenu.style.width === "5%") {
        return;
    }

    allMenus.forEach(menu => {
        menu.style.maxHeight = "0";
        menu.style.opacity = "0";
        menu.style.pointerEvents = "none";
    });

    const selectedMenu = element.parentElement.querySelector(".Contain");
    const currentHeight = window.getComputedStyle(selectedMenu).maxHeight;

    if (currentHeight !== "0px") {
        selectedMenu.style.maxHeight = "0";
        selectedMenu.style.opacity = "0";
        selectedMenu.style.pointerEvents = "none";
    } else {
        selectedMenu.style.maxHeight = "100vh";
        selectedMenu.style.opacity = "1";
        selectedMenu.style.pointerEvents = "auto";
    }
}

function toggleChildMenu(element) {
    const allChildMenus = document.querySelectorAll(".MenuContent ul");
    const sidebarMenu = document.querySelector(".Dashboard .Sidebar");

    if (sidebarMenu.style.width === "5%") {
        return;
    }

    allChildMenus.forEach(menu => {
        menu.style.display = "none";
    });

    const childMenu = element.parentElement.querySelector("ul");
    const currentDisplay = window.getComputedStyle(childMenu).display;

    if (currentDisplay !== "none") {
        childMenu.style.display = "none";
    } else {
        childMenu.style.display = "block";
    }
}

window.addEventListener("click", function (e) {
    const menuOption = document.querySelector(".Dashboard .MenuOption");
    const menuList = document.querySelector(".Dashboard .Sidebar");
    const logoIMG = document.querySelector(".Dashboard .Sidebar .Logo img");
    const logo = document.querySelector(".Dashboard .Sidebar .Logo");
    const contain = document.querySelectorAll(".Dashboard .Sidebar .Title .MenuContent");
    const textElements = document.querySelectorAll(".Dashboard .Sidebar .Title label");
    const paddingH2 = document.querySelectorAll(".Dashboard .Sidebar .Title h2");
    const content = document.querySelector(".DashboardContent");
    const span = document.querySelectorAll(".Dashboard .Sidebar .Title h2 span");

    if (e.target.closest(".MenuOption")) {
        if (menuList.style.width === "20%" || menuList.style.width === "") {
            menuList.style.width = "5%";
            menuOption.style.left = "5%";
            logoIMG.style.height = "2vh";
            logo.style.marginBottom = "0";
            logoIMG.style.marginLeft = "0.8em";
            content.style.marginLeft = "5%";

            span.forEach((span) => {
                span.style.position = "absolute";
                span.style.transform = "translate(-0.2em,-0.4em)";
            });

            contain.forEach((title) => {
                title.style.display = "none";
            });

            textElements.forEach((text) => {
                text.style.opacity = "0";
                text.style.pointerEvents = "none";
            });

            paddingH2.forEach((h2) => {
                h2.style.padding = "1.2em 1.5em"
            });
        } else {
            menuList.style.width = "20%";
            menuOption.style.left = "20%";
            logoIMG.style.height = "4vh";
            logo.style.marginBottom = "0.5em";
            logoIMG.style.marginLeft = "1.8em";
            content.style.marginLeft = "1em";

            span.forEach((span) => {
                span.style.position = "relative";
                span.style.transform = "translate(0,0)";
            });

            contain.forEach((title) => {
                title.style.display = "block";
            });

            textElements.forEach((text) => {
                text.style.opacity = "1";
                text.style.pointerEvents = "auto";
            });

            paddingH2.forEach((h2) => {
                h2.style.padding = "1em 2em"
            });
        }
    }
});

window.addEventListener("DOMContentLoaded", function () {
    const toggleSections = document.querySelectorAll(".OnOffSection");
    const toggleSectionsUpDown = document.querySelectorAll(".UpDownOption");
    const toggleSectionsHideShow = document.querySelectorAll(".ShowHideOption");

    toggleSections.forEach(section => {
        section.addEventListener("click", function () {
            toggleOnOff(this);
        });
    });

    toggleSectionsUpDown.forEach(section => {
        section.addEventListener("click", function () {
            toggleUpDown(this);
        });
    });

    toggleSectionsHideShow.forEach(section => {
        section.addEventListener("click", function () {
            toggleHideShow(this);
        });
    });

    toggleDateInput();
    showPage('DashboardHome', this);
    showSetting('GeneralSetting', this);
});

function toggleDateInput() {
    const option = document.getElementById("filterType").value;
    const date = document.getElementById("dateInput");
    const month = document.getElementById("monthInput");
    const year = document.getElementById("yearInput");

    date.style.display = "none";
    month.style.display = "none";
    year.style.display = "none";

    if (option === "day") {
        date.style.display = "unset";
    } else if (option === "month") {
        month.style.display = "unset";
    } else if (option === "year") {
        year.style.display = "unset";
    }
}

function showPage(onPage, element) {
    let pages = document.querySelectorAll('.DashboardContent > div');
    let titles = document.querySelectorAll('.Dashboard .Sidebar .Title .Contain .MenuContent ul li');
    pages.forEach(page => {
        page.style.display = "none";
    });

    titles.forEach(title => {
        title.style.color = "#adadad";
    });

    document.getElementById(onPage).style.display = "flex";
    element.style.color = "#2e2e2e";
};

function showSetting(page, element) {
    let pages = document.querySelectorAll('.SettingContent > div');
    let titles = document.querySelectorAll('.DashboardContent .DashboardSetting .SettingSidebar ul li');
    pages.forEach(page => {
        page.style.display = "none";
    });

    titles.forEach(title => {
        title.style.color = "#adadad";
    });

    document.getElementById(page).style.display = "flex";
    element.style.color = "#2e2e2e";
};

function toggleListOption(element) {
    const parent = element.closest(".Time").parentElement;
    const listMes = parent.querySelector(".ListOption");

    const isHidden = getComputedStyle(listMes).opacity === "0";

    if (isHidden) {
        listMes.style.opacity = "1";
        listMes.style.pointerEvents = "auto";
        listMes.style.maxHeight = "30vh";
    } else {
        listMes.style.opacity = "0";
        listMes.style.pointerEvents = "none";
        listMes.style.maxHeight = "0";
    }
}

function toggleMenuItems() {
    const menu = document.querySelector(".DashboardContent .DashboardMessaging .MessagingContent .MainMesaging .Items");

    if (menu.style.opacity === "0" || menu.style.opacity === "") {
        menu.style.opacity = "1"
        menu.style.maxWidth = "30%";
        menu.style.pointerEvents = "auto";
    } else {
        menu.style.opacity = "0"
        menu.style.maxWidth = "0";
        menu.style.pointerEvents = "none";
    }
}

function toggleInputItems() {
    const menu = document.querySelector(".DashboardContent .DashboardMessaging .MessagingContent .MainMesaging .MainTitle .OtherLink");

    if (menu.style.opacity === "0" || menu.style.opacity === "") {
        menu.style.opacity = "1"
        menu.style.pointerEvents = "auto";
        menu.style.right = "5.5em";
    } else {
        menu.style.opacity = "0"
        menu.style.pointerEvents = "none";
        menu.style.right = "7em";
    }
}

function toggleOnOff(section) {
    const toggleOn = section.querySelector(".ToggleOn");
    const toggleOff = section.querySelector(".ToggleOff");

    if (getComputedStyle(toggleOn).display === "none") {
        toggleOn.style.display = "flex";
        toggleOff.style.display = "none";
    } else {
        toggleOn.style.display = "none";
        toggleOff.style.display = "flex";
    }
}

function toggleUpDown(section) {
    const UpSection = section.querySelector(".UpSection");
    const DownSection = section.querySelector(".DownSection");
    const content = section.nextElementSibling;

    if (getComputedStyle(UpSection).display === "none") {
        UpSection.style.display = "flex";
        DownSection.style.display = "none";
        content.style.opacity = "1";
        content.style.maxHeight = " 100vh";
        content.style.pointerEvents = "auto";
        content.style.marginBottom = "1em";
    } else {
        UpSection.style.display = "none";
        DownSection.style.display = "flex";
        content.style.opacity = "0";
        content.style.maxHeight = "0";
        content.style.pointerEvents = "none";
        content.style.marginBottom = "0";
    }
}

function toggleHideShow(section) {
    const showIcon = section.querySelector(".Show");
    const hideIcon = section.querySelector(".Hide");
    const inputPass = section.querySelector(".ShowHideOption input");

    if (getComputedStyle(showIcon).display === "none") {
        inputPass.type = "password";
        showIcon.style.display = "flex";
        hideIcon.style.display = "none";
    } else {
        inputPass.type = "text";
        showIcon.style.display = "none";
        hideIcon.style.display = "flex";
    }
};

function toggleFilter(section) {
    const showFilter = section.querySelector(".Show");
    const hideFilter = section.querySelector(".Hide");
    const content = section.querySelector(".FilterManager")

    const isHidden = getComputedStyle(content).opacity === "0";

    if (isHidden) {
        hideFilter.style.display = "flex";
        showFilter.style.display = "none";
        content.style.opacity = "1";
        content.style.pointerEvents = "auto";
        content.style.minWidth = "30%";
        content.style.maxWidth = "50%";
        content.style.zIndex = "10";
    } else {
        hideFilter.style.display = "none";
        showFilter.style.display = "flex";
        content.style.opacity = "0";
        content.style.pointerEvents = "none";
        content.style.minWidth = "0%";
        content.style.maxWidth = "0%";
        content.style.zIndex = "0";
    }
};

function updateFileName() {
    const fileInput = document.getElementById("file-upload");
    const fileName = fileInput.files[0] ? fileInput.files[0].name : "Chưa chọn tệp nào";

    document.getElementById("file-name").textContent = fileName;
}

function closeAddTable(element) {
    const parent = element.closest(".Container"); const frame = parent.querySelector(".AddTable");

    const isHidden = getComputedStyle(frame).opacity === "0";

    if (isHidden) {
        frame.style.opacity = "1";
        frame.style.pointerEvents = "auto";
        frame.style.zIndex = "100";
    } else {
        frame.style.opacity = "0";
        frame.style.pointerEvents = "none";
        frame.style.zIndex = "0";
    }
}