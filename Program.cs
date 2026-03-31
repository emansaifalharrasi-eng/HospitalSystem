using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace HospitalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnoses = new string[100];
            bool[] admitted = new bool[100];// true = currently admitted
            string[] assignedDoctors = new string[100];
            string[] departments = new string[100]; // e.g. Cardiology, Orthopedics
            int[] visitCount = new int[100]; // total times admitted
            double[] billingAmount = new double[100]; // cumulative fees
            int lastPatientIndex = 0;



            // Seed Data with new fields
            patientNames[lastPatientIndex] = "Ali Hassan";
            patientIDs[lastPatientIndex] = "P001";
            diagnoses[lastPatientIndex] = "Flu";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            departments[lastPatientIndex] = "General"; // NEW
            visitCount[lastPatientIndex] = 2; // NEW
            billingAmount[lastPatientIndex] = 0; // NEW

            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Sara Ahmed";
            patientIDs[lastPatientIndex] = "P002";
            diagnoses[lastPatientIndex] = "Fracture";
            admitted[lastPatientIndex] = true;
            assignedDoctors[lastPatientIndex] = "Dr. Noor";
            departments[lastPatientIndex] = "Orthopedics"; // NEW
            visitCount[lastPatientIndex] = 4; // NEW
            billingAmount[lastPatientIndex] = 0; // NEW

            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Omar Khalid";
            patientIDs[lastPatientIndex] = "P003";
            diagnoses[lastPatientIndex] = "Diabetes";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            departments[lastPatientIndex] = "Cardiology"; // NEW
            visitCount[lastPatientIndex] = 1; // NEW
            billingAmount[lastPatientIndex] = 0; // NEW


            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("===== Hospital Managment System =====");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Admit Patient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. List All Admitted Patients");
                Console.WriteLine("6. Transfer Patient to Another Doctor ");
                Console.WriteLine("7. View Most Visited Patients"); // NEW
                Console.WriteLine("8. Search Patients by Department"); // NEW
                Console.WriteLine("9. Billing Report "); // NEw
                Console.WriteLine("10. runtime");
                Console.WriteLine("11. Exit");
                Console.Write("Choose option: ");



                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1://Register New Patient

                        lastPatientIndex++;

                        Console.Write("name: ");
                        patientNames[lastPatientIndex] = Console.ReadLine();

                        patientIDs[lastPatientIndex] = "P00" + lastPatientIndex;
                        Console.WriteLine("Patient ID: " + patientIDs[lastPatientIndex]);



                        Console.Write("patient ID: ");
                        patientIDs[lastPatientIndex] = Console.ReadLine();

                        Console.Write("diagnosis: ");
                        diagnoses[lastPatientIndex] = Console.ReadLine();

                        Console.Write("department: ");
                        departments[lastPatientIndex] = Console.ReadLine();

                        admitted[lastPatientIndex] = false;

                        Console.Write("assignedDoctor: ");
                        assignedDoctors[lastPatientIndex] = Console.ReadLine();
                        visitCount[lastPatientIndex] = 0;
                        billingAmount[lastPatientIndex] = 0;

                        Console.WriteLine("Patient registered  successfully!");

                        break;


                    case 2://Admit Patient

                        Console.Write("Enter patient ID or name: ");
                        string patientinput = Console.ReadLine();
                        Console.Write("Enter doctor name: ");
                        string doctorname = Console.ReadLine();

                        bool Patientadmitt = false;


                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == patientinput || patientIDs[i] == patientinput)
                            {

                                if (admitted[i] == false)
                                {
                                    Console.Write("patient name: ");
                                    patientNames[i] = Console.ReadLine();
                                    admitted[i] = false;
                                    visitCount[i]++;


                                    Console.WriteLine("Patient admitted successfully and assigned to" + assignedDoctors[i]);
                                    Console.WriteLine("Patient is already admitted under " + assignedDoctors[i] + visitCount[i] + " times");
                                }
                                else
                                {
                                    Console.WriteLine("Patient not found: " + patientNames[i]);
                                }

                                break;
                            }
                        }

                        if (Patientadmitt == false)
                        {
                            Console.WriteLine("Patient not found");
                        }


                        break;




                    case 3: //Discharge Patient

                        Console.Write("Enter patient ID or name: ");
                        string PatientInput = Console.ReadLine();

                        bool dischargeFound = false;
                        double totalCharges = 0;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == PatientInput || patientIDs[i] == PatientInput)
                            {
                                dischargeFound = true;

                                if (admitted[i] == true)
                                {
                                    Console.Write("Was there a consultation fee? (yes/no): ");
                                    string consultation = Console.ReadLine().ToLower();

                                    if (consultation == "yes")
                                    {
                                        Console.Write("Enter consultation fee amount (OMR): ");
                                        double billingAmount2 = Convert.ToDouble(Console.ReadLine());
                                        totalCharges += billingAmount2;
                                    }

                                    Console.Write("Any medication charges? (yes/no): ");
                                    string medication = Console.ReadLine().Trim().ToLower();

                                    if (medication == "yes")
                                    {
                                        Console.Write("Enter medication charges amount (OMR): ");
                                        double billingAmount3 = Convert.ToDouble(Console.ReadLine());
                                        totalCharges += billingAmount3;
                                    }

                                    billingAmount[i] += totalCharges;
                                    admitted[i] = false;

                                    if (totalCharges > 0)
                                    {
                                        Console.WriteLine("Total charges added this visit: " + totalCharges + " OMR");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No charges recorded");
                                    }

                                    Console.WriteLine("Patient discharged successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("This patient is not currently admitted");
                                }

                                break;
                            }
                        }

                        if (dischargeFound == false)
                        {
                            Console.WriteLine("Patient not found.");
                        }

                        break;
                    case 4://Search Patient

                        Console.WriteLine("Enter patient ID or name: ");
                        string searchInput = Console.ReadLine();

                        bool searchFound = false;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == searchInput || patientIDs[i] == searchInput)
                            {
                                searchFound = true;

                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine(" name: " + patientNames[i]);
                                Console.WriteLine("ID: " + patientIDs[i]);
                                Console.WriteLine("diagnosis: " + diagnoses[i]);
                                Console.WriteLine("department: " + departments[i]);
                                Console.WriteLine("admission status: " + admitted[i]);
                                Console.WriteLine("visit count: " + visitCount[i]);
                                Console.WriteLine("total billing amount: " + billingAmount[i]);

                                if (admitted[i] == false)
                                {
                                    Console.WriteLine("show assigned doctor: " + assignedDoctors[i]);
                                }
                                Console.WriteLine("----------------------------------------");


                            }
                        }

                        if (searchFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }

                        break;




                    case 5://List All Admitted Patients

                        Console.WriteLine("Admitted Patients :");
                        Console.WriteLine("");

                        bool isAdmitted = false;
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (admitted[i] == true)
                            {
                                Console.WriteLine("name: " + patientNames[i] + " | ID: " + patientIDs[i] + " | Diagnosis: " + diagnoses[i] + " | Department: " + departments[i]);
                                isAdmitted = true;
                            }
                        }

                        if (isAdmitted == false)
                        {
                            Console.WriteLine("No patient admitt at the moment");
                        }


                        break;

                    case 6://Transfer Patient to Another Doctor 

                        Console.Write("Enter current doctor name: ");
                        string firstDoctor = Console.ReadLine();

                        Console.Write("Enter new doctor name: ");
                        string secondDoctor = Console.ReadLine();

                        bool firstDoctorFound = false;
                        int firstDoctorIndex = 0;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (firstDoctor == assignedDoctors[i])
                            {
                                firstDoctorIndex = i;
                                firstDoctorFound = true;
                                break;
                            }
                        }

                        if (firstDoctorFound == false)
                        {
                            Console.WriteLine("Current doctor name not found");
                        }
                        else
                        {
                            assignedDoctors[firstDoctorIndex] = secondDoctor;
                            Console.WriteLine("doctor transferred successfully!");
                            Console.WriteLine("doctor " + patientNames[firstDoctorIndex] + " is now transferd by " + secondDoctor);
                        }


                        break;

                    case 7://View Most Visited Patients

                        Console.WriteLine("Most Visited Patients :");
                        Console.WriteLine("--");

                        for (int count = 100; count >= 0; count--) // Start from highest possible count
                        {
                            for (int i = 0; i <= lastPatientIndex; i++)
                            {
                                if (visitCount[i] == count)
                                {
                                    Console.WriteLine("Name: " + patientNames[i] + " | ID: " + patientIDs[i] + "  Department: " + departments[i] + " diagnoses:" + diagnoses[i] + " visitCount: " + visitCount[i]);
                                }
                            }
                        }


                        break;

                    case 8://Search Patients by Department

                        Console.Write("Enter department name: ");
                        string searchdepartment = Console.ReadLine();

                        bool departmentFound = false;

                        Console.WriteLine("patient in department '" + searchdepartment + "':");
                        Console.WriteLine("---");

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (departments[i].ToLower() == searchdepartment.ToLower())
                            {
                                departmentFound = true;
                                string admitStatus = admitted[i] ? "admitted" : " Not admitt";
                                Console.WriteLine("name: " + patientNames[i] + " | ID: " + patientIDs[i] + " | Diagnosis: " + diagnoses[i] + " | Admission Status : " + admitStatus);
                            }
                        }

                        if (departmentFound == false)
                        {
                            Console.WriteLine("No patient found in this department");
                        }

                        break;



                    case 9://Billing Report

                        Console.WriteLine("Billing Report:");
                        Console.WriteLine("1. System-wide total");
                        Console.WriteLine("2. Individual patient");
                        Console.Write("Choose option: ");
                        int BillingOption = int.Parse(Console.ReadLine());

                        if (BillingOption == 1)
                        {
                            double totalBill = 0;

                            for (int i = 0; i <= lastPatientIndex; i++)
                            {
                                totalBill += billingAmount[i];
                            }

                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Total bill: " + totalBill + " OMR");
                        }
                        else if (BillingOption == 2)
                        {
                            Console.Write("Enter patient name or ID: ");
                            string Input = Console.ReadLine();

                            double patientbill = 0;
                            bool found = false;

                            for (int i = 0; i <= lastPatientIndex; i++)
                            {
                                if (patientNames[i] == Input || patientIDs[i] == Input)
                                {
                                    patientbill += billingAmount[i];
                                    found = true;
                                }
                            }

                            if (found)
                            {
                                Console.WriteLine("Billing amount for " + Input + ": " + patientbill + " OMR");
                            }
                            else
                            {
                                Console.WriteLine("No billing records found for this patient");
                            }
                        }
                        break;




                    case 10: // Exit

                        Console.WriteLine("Exiting program...");
                        Console.WriteLine("Thank you for using the Healthcare Management System");
                        Console.WriteLine("----------------------------------------");

                        exit = true;

                        break;

                    case 11:
                        try
                        {
                            int divisor = 0;
                            int result = 10 / divisor;
                            Console.WriteLine(result);
                        }
                        catch (DivideByZeroException ex)
                        { Console.WriteLine("Error: " + ex.Message); }


                        break;


                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}






















