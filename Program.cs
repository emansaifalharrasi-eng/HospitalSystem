using System.Collections.Generic;
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
            bool[] admitted = new bool[100]; // true = currently admitted
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
                Console.WriteLine("9. Billing Report "); // NEW
                Console.WriteLine("10. Exit");
                Console.Write("Choose option: ");



                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1://Register New Patient

                        lastPatientIndex++;

                        Console.Write("name: ");
                        patientNames[lastPatientIndex] = Console.ReadLine();

                        Console.Write("patient ID: ");
                        patientIDs[lastPatientIndex] = Console.ReadLine();

                        Console.Write("diagnosis: ");
                        diagnoses[lastPatientIndex] = Console.ReadLine();

                        Console.Write("department: ");
                        departments[lastPatientIndex] = Console.ReadLine();

                        admitted[lastPatientIndex] = false;
                        assignedDoctors[lastPatientIndex] = "";
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

                                if (admitted[i] == true)
                                {
                                    Console.Write("patient name: ");
                                    assignedDoctors[i] = Console.ReadLine();
                                    admitted[i] = true;
                                    visitCount[i]++; 
                                   

                                    Console.WriteLine("Patient admitted successfully and assigned to [doctor]!");
                                    Console.WriteLine("Patient is already admitted under [doctor] " + visitCount[i] + " times"); 
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

                        bool PatientDischrge = false;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == PatientInput || patientIDs[i] == PatientInput)
                            {
                                PatientDischrge = true;

                                if (admitted[i] == false)
                                {
                                    Console.WriteLine("This patient is not currently admitted");

                                    string billingAmount = 0;


                                    Console.Write("Was there a consultation fee? (yes/no): ");
                                    string consultation = Console.ReadLine().Time().ToLower();
                                    if (consultation == "yes")
                                    {
                                        Console.Write("Enter consultation fee amount (OMR): ");
                                        billingAmount += Convert.ToDouble(Console.ReadLine());

                                        Console.Write("Any medication charges? (yes/no): ");
                                        string medication = Console.ReadLine().Trim().ToLower();
                                        if (medication == "yes")
                                        {
                                            Console.Write("Enter medication charges amount (OMR): ");
                                            billingAmount += Convert.ToDouble(Console.ReadLine());
                                        }

                                    }
                                }

                                   

                                    if (billingAmount > 0)
                                    {
                                        Console.WriteLine($"Total charges added this visit: {billingAmount} OMR");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No charges recorded");
                                    }

                                    Console.WriteLine("Patient discharged successfully!");


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

                                        if (admitted[i] == true)
                                        {
                                            Console.WriteLine("show assigned doctor: " + assignedDoctors[i]);
                                        }
                                        Console.WriteLine("----------------------------------------");




                                        if (searchFound == false)
                                        {
                                            Console.WriteLine("Patient not found");
                                        }

                                        break;




                        case 5://List All Admitted Patients

                                                Console.WriteLine("Available Admitted Patients :");
                                                Console.WriteLine("----------------------------------------");

                                                bool hasAvailable = false;
                                                for (int i = 0; i <= lastPatientIndex; i++)
                                                {
                                                    if (admitted[i] == true)
                                                    {
                                                        Console.WriteLine("name: " + patientNames[i] + " | ID: " + patientIDs[i] + " | ISBN: " + isbns[i] + " | Category: " + categories[i]);
                                                        hasAvailable = true;
                                                    }
                                                }

                                                if (hasAvailable == false)
                                                {
                                                    Console.WriteLine("No books available at the moment");
                                                }


                                                break;

                                        case 6://Transfer Patient to Another Doctor 

                                                Console.Write("Enter current patient name: ");
                                                string firstPtient = Console.ReadLine();

                                                Console.Write("Enter new borrower name: ");
                                                string secondBorrower = Console.ReadLine();

                                                bool firstBorrowerFound = false;
                                                int firstBorrowerIndex = 0;

                                                for (int i = 0; i <= lastPatientIndex; i++)
                                                {
                                                    if (firstBorrower == borrowers[i])
                                                    {
                                                        firstBorrowerIndex = i;
                                                        firstBorrowerFound = true;
                                                        break;
                                                    }
                                                }

                                                if (firstBorrowerFound == false)
                                                {
                                                    Console.WriteLine("Current borrower name not found");
                                                }
                                                else
                                                {
                                                    borrowers[firstBorrowerIndex] = secondBorrower;
                                                    Console.WriteLine("Book transferred successfully!");
                                                    Console.WriteLine("Book '" + titles[firstBorrowerIndex] + "' is now borrowed by " + secondBorrower);
                                                }


                                                break;

                                        case 7:
                                            break;

                                        case 8:
                                            break;

                                        case 9:
                                            break;

                                        case 10: // Exit
                                            Console.WriteLine("Exiting program...");
                                            Console.WriteLine("Thank you for using Hospital Management System!");
                                            Console.WriteLine("----------------------------------------");

                                            exit = true;

                                            break;

                                        default:
                                            Console.WriteLine("Invalid option. Please try again.");
                                            break;
                                        }

                                        Console.WriteLine("Press any key to continue...");
                                        Console.ReadKey();
                                        Console.Clear();

                                    
        

    







                
            

