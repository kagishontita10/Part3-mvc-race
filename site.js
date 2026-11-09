function toast(m) { let t = document.getElementById('toast'); if (!t) return; t.textContent = m; t.style.display = 'block'; setTimeout(() => t.style.display = 'none', 2500); }
document.addEventListener("DOMContentLoaded", function () {
    var forms = document.querySelectorAll("form");
    forms.forEach(function (form) {
        form.addEventListener("submit", function (e) {
            var inputs = form.querySelectorAll("input[required], select[required]");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].value.trim() === "") { e.preventDefault(); inputs[i].setCustomValidity("Please fill out this field"); inputs[i].reportValidity(); return; }
                else { inputs[i].setCustomValidity(""); }
            }
        });
    });
    var allInputs = document.querySelectorAll("input");
    allInputs.forEach(function (input) { input.addEventListener("input", function () { input.setCustomValidity(""); }); });
    var profileForm = document.getElementById("profileForm");
    if (profileForm) { profileForm.addEventListener("submit", function () { var msg = document.getElementById("profileMessage"); if (msg) { msg.textContent = "Profile saved successfully"; msg.className = "toast"; msg.style.display = "block"; } }); }
});
