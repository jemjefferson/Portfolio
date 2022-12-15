// Skill List
let skills = ["C#/.NET Framework", "ASP.NET MVC", "HTML / CSS / JavaScript", "T-SQL/Microsoft SQL Server/SSIS",
    "Web APIs", "Azure DevOps/Azure Services", "Communication/Technical Writing"];
let skillList = document.getElementById("skillList");

for (let i = 0; i < skills.length; i++) {
    skillList.innerHTML += `<li>${skills[i]}</li>`;
}

// Degree/Certificate Table
let degrees = [{ Name: "Software Developer", Type: "Associate Degree", Year: 2023 }, { Name: "Software Development Specialist", Type: "Technical Degree", Year: 2022 },
    { Name: "Junior Developer", Type: "Technical Degree", Year: 2022 }, { Name: "Mathematics", Type: "Certificate", Year: 2022 },
    {Name: "Communication", Type: "Certificate", Year: 2022}];

let degreeTable = document.getElementById("degreeTable");

for (let i = 0; i < degrees.length; i++) {
    degreeTable.innerHTML += `<tr>
                                <td>${degrees[i].Name}</td>
                                <td>${degrees[i].Type}</td>
                                <td>${degrees[i].Year}</td>
                              </tr>`
};