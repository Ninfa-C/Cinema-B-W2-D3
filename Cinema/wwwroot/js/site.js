function updateMovies() {
    var salaId = document.getElementById("SaleID").value;
    if (salaId) {
        window.location.href = baseUrl + '?SalaScelta=' + salaId;
    }
}