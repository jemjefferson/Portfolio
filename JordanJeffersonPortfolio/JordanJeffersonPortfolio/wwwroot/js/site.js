// Degree/Certificate Table
let degrees = [{ Name: "Software Developer", Type: "Associate Degree"}, { Name: "Software Development Specialist", Type: "Technical Degree"},
    { Name: "Junior Developer", Type: "Technical Degree" }, { Name: "Mathematics", Type: "Certificate"},
    {Name: "Communication", Type: "Certificate"}];

let degreeTable = document.getElementById("degreeTable");

for (let i = 0; i < degrees.length; i++) {
    if (i % 2 == 0) {
        degreeTable.innerHTML += `<tr class="tableRow1">
                                <td>${degrees[i].Name}</td>
                                <td>${degrees[i].Type}</td>
                              </tr>`
    }
    else {
        degreeTable.innerHTML += `<tr class="tableRow2">
                                <td>${degrees[i].Name}</td>
                                <td>${degrees[i].Type}</td>
                              </tr>`
    }
};