# 🩺 CMPG122 Final Assessment — SOT Clinic Management System

[![Made with Visual Studio](https://img.shields.io/badge/Made%20With-Visual%20Studio-blue?style=for-the-badge&logo=visualstudio)](https://visualstudio.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=c-sharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/Platform-.NET%20Framework-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)

---

## 👨🏾‍💻 Author Information
**Student:** Tebogo Jr Mabuza  
**Student Number:** 49461168  
**Module:** CMPG122 — Introduction to Programming  
**Institution:** North-West University  
**Academic Year:** 2025  

---

## 🧠 Project Overview
The **SOT Clinic Management System** is a **Windows Forms Application** created as the final assessment for CMPG122.  
It simulates a clinic’s workflow, covering **patient intake**, **billing**, and **performance tracking**.

This project demonstrates proficiency in C# fundamentals (Chapters 1–9 from *Tony Gaddis — Starting Out with Visual C#*), showcasing key programming concepts like arrays, loops, file I/O, methods, and UI event handling.

---

## 🏗️ Application Architecture

| Form | Purpose | Key Concepts |
|------|----------|---------------|
| **Login Form** | Basic authentication for admin access | Conditional logic, navigation between forms |
| **Client Intake Form** | Captures patient details, calculates total fees | Arrays, loops, methods, file writing |
| **Dashboard Form** | Displays KPIs and recent records | File reading, parsing, aggregation, conditional formatting |

---

## 🧩 Features
✅ **Three-form navigation flow** (Login → Intake → Dashboard)  
✅ **Service price calculation** using arrays and loops  
✅ **Dynamic fee adjustment** using `ref` parameter method  
✅ **File persistence** with `StreamWriter` and `StreamReader`  
✅ **Defensive parsing** for malformed data  
✅ **Random ID generation** for new clients (`SOT-XXXXXX`)  
✅ **Conditional color change** (Revenue KPI: green/red)  
✅ **Summary export file generation** (`SOT_summary_exports.txt`)  
✅ **Keyboard mnemonics and basic validation**  

---

## 💡 Core Methods

### 🔹 `decimal CalculateTotalFee()`
Calculates the total cost for selected services, funding type, and add-ons.  
Returns the computed fee as a `decimal` value.

### 🔹 `void ApplyFeeAdjustment(ref decimal fee, decimal percentAdjustment)`
Applies a percentage adjustment (e.g., 5% discount) to the total fee.  
Uses a **`ref` parameter** to permanently modify the variable passed in.

### 🔹 `void LoadKpis()`
Reads data from `SOT_records.txt` and updates the Dashboard KPIs:
- **Total Clients**
- **Total Revenue**
- **Average Fee**
- **Outstanding Claims**

Includes robust error handling for missing or malformed lines and dynamically updates colors:
```csharp
if (totalRevenue >= 10000m)
{
    revenueLabelKPI.BackColor = Color.Green;
    revenueLabelKPI.ForeColor = Color.White;
}
else
{
    revenueLabelKPI.BackColor = Color.DarkRed;
    revenueLabelKPI.ForeColor = Color.White;
}

📂 Project Structure

CMPG122_FINAL_ASSESSMENT/
│
├── CMPG122_FINAL_ASSESSMENT.sln          # Solution file
├── /CMPG122_FINAL_ASSESSMENT/
│   ├── FormLogin.cs
│   ├── FormClientIntake.cs
│   ├── FormDashboard.cs
│   ├── Program.cs
│   ├── Properties/
│   └── Resources/
│
├── SOT_records.txt                       # Stores client registration data
├── SOT_summary_exports.txt               # Stores exported summaries
└── README.md                             # Project documentation

🧮 Example Data

SOT_records.txt
2025-11-07 22:04	SOT-723218	James Blake	25	Medical Aid	513,00
2025-11-07 22:45	SOT-316646	Princess Vilakazi	7	Medical Aid	665,00
2025-11-07 23:52	SOT-103163	John Adams	23	Private	760,00

SOT_summary_exports.txt
2025-11-08 06:28	Clients: 11	Revenue: R 6450,50

⚙️ Setup & Running

🔧 Prerequisites
	•	Visual Studio 2022 or later
	•	.NET Framework (Windows Forms)
	•	OS: Windows 10/11

▶️ How to Run
	1.	Clone this repository:
git clone https://github.com/<your-username>/CMPG122_FINAL_ASSESSMENT.git

2.	Open CMPG122_FINAL_ASSESSMENT.sln in Visual Studio.
	3.	Build and run the project.
	4.	Login using:
Username: admin
Password: sot2025

🎥 Demonstration

A 7-minute demonstration video was recorded using Loom as part of the final assessment.

📺 Watch here: (https://www.loom.com/share/899760b2b1c44b55b4cb56b147f03a68)

The video showcases:

	•	Login and Intake flow
	•	Fee calculation and registration
	•	File writing to SOT_records.txt
	•	Dashboard KPI updates and color changes
	•	Explanation of core code and methods

🚀 Future Improvements

	•	Add database integration (SQLite or SQL Server) instead of text files.
	•	Implement search and edit functionality for registered clients.
	•	Create modern UI with WPF or MAUI.
	•	Add input validation using regular expressions.

🧾 License

This project was created for educational purposes as part of the CMPG122 module at North-West University.
All rights reserved © 2025 — Tebogo Jr Mabuza.

📬 Contact

👤 Tebogo Jr Mabuza
📧 Email: tebogomabuzaa@gmail.com
🎓 Student Number: 49461168
🏫 North-West University
🗓️ 2025 Academic Year
