addEventListener("DOMContentLoaded", () => {
    if(sessionStorage.getItem('username') == null) {
        location.href = "form.html";
    }
});