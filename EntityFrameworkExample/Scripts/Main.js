function sortTable(n, id) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById(id == 0 ? "indexTableBarrel" : "indexTableCube");
    switching = true;
    dir = "asc";
    while (switching) {
        switching = false;
        rows = table.rows;
        console.log(table);
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n].innerHTML;
            y = rows[i + 1].getElementsByTagName("TD")[n].innerHTML;
            if (dir == "asc") {
                if ((!isNaN(Number(x)) && Number(x) > Number(y)) ||
                    (Date.parse(x) instanceof Date && Date(x) > Date(y)) ||
                    (x.trim().toLowerCase() > y.trim().toLowerCase())) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if ((!isNaN(Number(x)) && Number(x) < Number(y)) ||
                    (Date.parse(x) instanceof Date && Date(x) < Date(y)) ||
                    (x.trim().toLowerCase() < y.trim().toLowerCase())) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}
function searchTable(n) {
    var input, filter, table, tr, td, th, i, txtValue;
    if (n == 0) {
        input = document.getElementById("searchBoxBarrel");
        filter = input.value.toUpperCase();
        table = document.getElementById("indexTableBarrel");
        tr = table.getElementsByTagName("tr");
        th = table.getElementsByTagName("th");
    }
    else {
        input = document.getElementById("searchBoxCube");
        filter = input.value.toUpperCase();
        table = document.getElementById("indexTableCube");
        tr = table.getElementsByTagName("tr");
        th = table.getElementsByTagName("th");      
    }
    for (i = 1; i < tr.length; i++) {
        tr[i].style.display = "none";
    }
    for (j = 0; j < th.length; j++) {
        for (i = 1; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[j];
            if (td) {
                txtValue = td.textContent || td.innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1)
                    tr[i].style.display = "";
            }
        }
    }

}
