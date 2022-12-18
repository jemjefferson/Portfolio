// Degree/Certificate Table
let degrees = [{ Name: "Software Developer", Type: "Associate Degree", Year: 2023 }, { Name: "Software Development Specialist", Type: "Technical Degree", Year: 2022 },
    { Name: "Junior Developer", Type: "Technical Degree", Year: 2022 }, { Name: "Mathematics", Type: "Certificate", Year: 2022 },
    {Name: "Communication", Type: "Certificate", Year: 2022}];

let degreeTable = document.getElementById("degreeTable");

for (let i = 0; i < degrees.length; i++) {
    if (i % 2 == 0) {
        degreeTable.innerHTML += `<tr class="tableRow1">
                                <td>${degrees[i].Name}</td>
                                <td>${degrees[i].Type}</td>
                                <td>${degrees[i].Year}</td>
                              </tr>`
    }
    else {
        degreeTable.innerHTML += `<tr class="tableRow2">
                                <td>${degrees[i].Name}</td>
                                <td>${degrees[i].Type}</td>
                                <td>${degrees[i].Year}</td>
                              </tr>`
    }
};