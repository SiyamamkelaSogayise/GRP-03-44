var timelineSwiper = new Swiper('.timeline .swiper-container', {
    direction: 'vertical',
    loop: false,
    speed: 1600,
    pagination: '.swiper-pagination',
    paginationBulletRender: function (swiper, index, className) {
        var year = document.querySelectorAll('.swiper-slide')[index].getAttribute('data-year');
        return '<span class="' + className + '">' + year + '</span>';
    },
    paginationClickable: true,
    nextButton: '.swiper-button-next',
    prevButton: '.swiper-button-prev',
    breakpoints: {
        768: {
            direction: 'horizontal',
        }
    }
});

//const items = document.querySelectorAll(".slider-item");
//const itemCount = items.length;
//const nextItem = document.querySelector(".next");
//const previousItem = document.querySelector(".previous");
//const navItem = document.querySelector("a.toggle-nav");
//let count = 0;

//function showNextItem() {
//    items[count].classList.remove("active");

//    if (count < itemCount - 1) {
//        count++;
//    } else {
//        count = 0;
//    }

//    items[count].classList.add("active");
//    console.log(count);
//}

//function showPreviousItem() {
//    items[count].classList.remove("active");

//    if (count > 0) {
//        count--;
//    } else {
//        count = itemCount - 1;
//    }

//    items[count].classList.add("active");
//    // Check if working...
//    console.log(count);
//}

//function toggleNavigation() {
//    this.nextElementSibling.classList.toggle("active");
//}

//function keyPress(e) {
//    e = e || window.event;

//    if (e.keyCode == "37") {
//        showPreviousItem();
//    } else if (e.keyCode == "39") {
//        showNextItem();
//    }
//}

//nextItem.addEventListener("click", showNextItem);
//previousItem.addEventListener("click", showPreviousItem);
//document.addEventListener("keydown", keyPress);
//navItem.addEventListener("click", toggleNavigation);