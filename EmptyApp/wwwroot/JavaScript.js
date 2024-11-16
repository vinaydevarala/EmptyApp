document.querySelector("#All-Details").addEventListener("click", async function () {
    event.preventDefault();
    var response =await fetch("ViewComponentResult");
    var responsebody = await response.text();
    document.querySelector("#Data").innerHTML = responsebody;
});