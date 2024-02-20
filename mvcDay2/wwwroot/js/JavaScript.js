function getManger(id, id2) {

  
    $.ajax({
        url: `/workfor/gethoures?id=${id}&&id2=${id2}`,
        success: function (result) {
            console.log(result);
            var area = document.getElementById("hour");
            area.innerHTML = result;
        }
    });

}