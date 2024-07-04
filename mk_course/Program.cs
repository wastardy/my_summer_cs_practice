using System;

namespace test_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region practice_module_5
            
            // Prpgram ---> Schools attend zoo
            /*
            // -----> Start From Pseudo-Code <-----
            //
            // - There will be three visiting schools
            //     - School A has 6 visiting groups (the default number)
            //     - School B has 3 visiting groups
            //     - School C has 2 visiting groups
            //
            // - For each visiting school, perform the following tasks
            //     - Randomize the animals
            //     - Assign the animals to the correct number of groups
            //     - Print the school name
            //     - Print the animal groups

            string[] pettingZoo = 
            {
                "alpacas", "capybaras", "chickens", "ducks", "emus", "geese", 
                "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws", 
                "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
            };

            PlanSchoolVisit("School A");
            PlanSchoolVisit("School B", 3);
            PlanSchoolVisit("School C", 2);
            
            void PlanSchoolVisit(string schoolName, int groups = 6)
            {
                RandomizeAnimals();
                string[,] group = AssignGroup(groups);
                Console.WriteLine("\n" + schoolName);
                PrintGroup(group);
            }

            void RandomizeAnimals()
            {
                Random random = new Random();

                for (int i = 0; i < pettingZoo.Length; i++)
                {
                    int r = random.Next(i, pettingZoo.Length);

                    string temp = pettingZoo[i];
                    pettingZoo[i] = pettingZoo[r];
                    pettingZoo[r] = temp;
                }
            }

            string[,] AssignGroup(int animalGroups = 6)
            {
                int start = 0;
                int animalsPerGroup = pettingZoo.Length / animalGroups;

                string[,] result = new string[animalGroups, animalsPerGroup];

                for (int i = 0; i < animalGroups; i++)
                {
                    for (int j = 0; j < animalsPerGroup; j++)
                    {
                        result[i, j] = pettingZoo[start++];
                    }
                }

                return result;
            }

            // -------> GetLength(0) to get the number of rows in the array
            // -------> GetLength(1) to get the number of columns.
            void PrintGroup(string[,] group)
            {
                for (int i = 0; i < group.GetLength(0); i++)
                {
                    Console.Write($"Group {i + 1}: ");
                    for (int j = 0; j < group.GetLength(1); j++)
                    {
                        Console.Write($"{group[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
            */

            // challenge: dice mini-game
            /*
            Random random = new Random();

            Console.Write("\nWould you like to play? (y/n): ");
            if (WannaPlay())
            {
                PlayGame();
            }
            else 
            {
                Console.WriteLine("\nCatch ya later, bye!\n");
            }

            void PlayGame()
            {
                var play = true;

                while (play)
                {
                    var target = random.Next(1, 6);
                    var roll = random.Next(1, 6);

                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine($"Roll a number grater than {target} to win!");
                    Console.WriteLine($"You rolled: {roll}");
                    WinOrLose(target, roll);
                    Console.WriteLine("-----------------------------------");
                    Console.Write("Wanna play again? (y/n): ");

                    play = WannaPlay();
                    Console.Clear();
                }

                if (play == false)
                {
                    Console.WriteLine("\nCatch ya later, bye!\n");
                }
            }

            bool WannaPlay()
            {
                string? userInput = "";
                do 
                {
                    userInput = Console.ReadLine();
                } 
                while (userInput.ToLower() != "y" 
                    && userInput.ToLower() != "n");

                // return userInput.ToLower == "y" ? true : false;

                if (userInput.ToLower() == "n")
                {
                    return false;
                }
                return true;
            }

            void WinOrLose(int num1, int num2)
            {
                if (num1 >= num2)
                {
                    Console.WriteLine("You lose, maybe next time..");
                }
                else
                {
                    Console.WriteLine("God damn! You win!");
                }
            }
            */

            // challenge: is current word palindrome??
            /*
            string[] words = {"racecar" ,"talented", "deified", "tent", "tenet"};

            Console.WriteLine("Is Palindrome?");
            foreach (string word in words)
            {
                Console.WriteLine($"{word}: {IsPalindrome(word)}");
            }

            bool IsPalindrome(string word)
            {
                int start = 0;
                int end = word.Length - 1;

                while (start< end) 
                {
                    if (word[start] != word[end])
                    {
                        return false;
                    }
                    start++;
                    end--;
                }

                return true;
            }
            */

            // challenge: reverse each word in a given sentence, 
            // maintaining the original position of each word.
            /*
            string sentence = "Today is rainy day and I decided to stay at home";

            Console.WriteLine("\nInnitial Sentence: " + sentence);
            Console.WriteLine("Reversed Sentence: " + ReverseSentence(sentence) + "\n");

            string ReverseSentence(string input)
            {
                string reversedSentence = "";
                string[] words = input.Split(" ");

                foreach (var word in words)
                {
                    reversedSentence += ReversedWord(word) + " ";
                }

                return reversedSentence.Trim();
            }

            string ReversedWord(string word)
            {
                string reversedWord = "";
                for (int i = word.Length - 1 ; i >= 0; i--)
                {
                    reversedWord += word[i];
                }

                return reversedWord;
            }
            */

            // challenge: display email addresses
            /*
            string[,] corporate = 
            {
                {"Robert", "Bavin"}, {"Simon", "Bright"},
                {"Kim", "Sinclair"}, {"Aashrita", "Kamath"},
                {"Sarah", "Delucchi"}, {"Sinan", "Ali"}
            };

            string[,] external = 
            {
                {"Vinnie", "Ashton"}, {"Cody", "Dysart"},
                {"Shay", "Lawrence"}, {"Daren", "Valdes"}
            };

            string externalDomain = "hayworth.com";
            
            System.Console.WriteLine();
            for (int i = 0; i < corporate.GetLength(0); i++) 
            {
                createEmail([corporate[i, 0], corporate[i, 1]]);
            }

            for (int i = 0; i < external.GetLength(0); i++) 
            {
                createEmail([external[i, 0], external[i, 1]], domain: externalDomain);
            }
            System.Console.WriteLine();


            void createEmail(string[] names, string domain = "contoso.com")
            {
                string email = names[0].Substring(0, 2) + names[1] + "@" + domain;
                System.Console.WriteLine(email.ToLower());
            }
            */

            // RSVP Application   |   i ~About functions
            /*
            string[] guestList = {"Rebecca", "Nadia", "Noor", "Jonte"};
            string[] rsvps = new string[10];
            int count = 0;

            // 1) named arguments can improve the REDABILITY of your code
            RSVP(name: "Linh", partySize: 2, allergies: "none", inviteOnly: false);
            // 2) named arguments DON'T have to appear in the ORIGINAL ORDER.
            RSVP("Tony", inviteOnly: true, allergies: "Jackfruit");
            
            RSVP("Rebecca");
            RSVP("Nadia", 2, "Nuts");
            RSVP("Noor", 4, allergies: "none", false);
            RSVP("Jonte", 2, "Stone fruit", false);
            ShowRSVPs();

            // optional parameter
            void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)
            {
                if (inviteOnly)
                {
                    bool found = false;
                    foreach (string guest in guestList)
                    {
                        if (guest.Equals(name))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"Sorry, {name} is not on the guest list");
                        return;
                    }
                }

                rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, Allergies: {allergies}";
                count++;
            }

            void ShowRSVPs()
            {
                Console.WriteLine("\nTotal RSVPs:");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(rsvps[i]);
                }
            }
            */

            // tell fortune in game
            /*

            Console.WriteLine("\nA fortune teller whispers the following words:");
            Console.WriteLine("----------------------------------------------");
            
            for (int i = 0; i < 3; i++) 
            {
                TellFortune();
            }

            void TellFortune()
            {
                Random random = new Random();
                int luck = random.Next(100);

                string[] text = {"You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to"};
                string[] good = {"look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!"};
                string[] bad = {"fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life."};
                string[] neutral = {"appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature."};

                string[] fortune = (luck > 75 ? good : (luck < 25 ? bad : neutral));
                for (int i = 0; i < 4; i++) 
                {
                    Console.WriteLine($"{text[i]} {fortune[i]} ");
                }
                Console.WriteLine("----------------------------------------------\n");
            }
            */

            // Program ---> Checks is an IPv4 address valid.
            /*

            // * four numbers separated by dots
            // * not contain leading zeroes
            // * number must range from 0 to 255
            
            //  pseudo-code: 
            //
            //  if ipAddress consists of 4 numbers
            //  and
            //  if each ipAddress number has no leading zeroes
            //  and
            //  if each ipAddress number is in range 0 - 255
            //
            //  then ipAddress is valid
            //
            //  else ipAddress is invalid

            string[] ipv4Input = {"107.31.1.5", "255.0.0.255", "555.1.1.555", "255...255"};

            foreach (var ip in ipv4Input)
            {
                if (ValidateLength(ip) 
                && ValidateZeros(ip) 
                && ValidateRange(ip))
                {
                    Console.WriteLine($"\n{ip} is a valid IPv4 address\n");
                }
                else 
                {
                    Console.WriteLine($"\n{ip} is an invalid IPv4 address");
                    
                    if (ValidateLength(ip) == false)
                    {
                        Console.WriteLine("Error is related to invalid length of ip address\n");
                    }
                    else if (ValidateZeros(ip) == false)
                    {
                        Console.WriteLine("Error is related to leading zero in one of octet\n");
                    }
                    else if (ValidateRange(ip) == false)
                    {
                        Console.WriteLine("Error is related to octet's range is out of range\n");
                    }
                    else 
                    {
                        Console.WriteLine("Unknown error:(\n");
                    }
                }

            }

            bool ValidateLength(string ipv4)
            {
                string[] parts = ipv4.Split(".", StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 4)
                {
                    return true;
                }
                return false;
            }

            bool ValidateZeros(string ipv4)
            {  
                string[] parts = ipv4.Split(".", StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    // ----------------------> .StartsWith("0")
                    if (part.Length > 0 && part[0] == '0')
                    {
                        return false;
                    }
                }
                return true;
            }

            bool ValidateRange(string ipv4)
            {  
                string[] parts = ipv4.Split(".", StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in parts)
                {
                    int value = int.Parse(part);
                    if (value < 0 || value > 255)
                    {
                        return false;
                    }
                }
                return true;
            }
            */

            // Program ---> GMT Medicine Schedule
            /*
            int[] times = {800, 1200, 1600, 2000};
            int diff = 0;

            Console.WriteLine("\n-----------------------");
            Console.Write("Enter CURRENT GMT: ");
            int currentGMT = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("\nCurrentGMT Medicine Schedule:");
            DisplayTimes();

            Console.WriteLine("-----------------------");
            Console.Write("Enter NEW GMT: ");
            int newGMT = Convert.ToInt32(Console.ReadLine());

            if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
            {
                Console.WriteLine("Invalid GMT");
            }
            else if (newGMT <= 0 && currentGMT <= 0
                    || newGMT >= 0 && currentGMT >= 0)
            {
                diff = 100 * (Math.Abs(newGMT) 
                            - Math.Abs(currentGMT));
                AdjustTimes();
            }
            else
            {
                diff = 100 * (Math.Abs(newGMT) 
                            + Math.Abs(currentGMT));
                AdjustTimes();
            }

            Console.WriteLine("\nNew Medicine Schedule:");
            DisplayTimes();
            Console.WriteLine("-----------------------\n");

            void DisplayTimes()
            {
                foreach (int value in times) 
                {
                    string time = value.ToString();
                    int lenght = time.Length;

                    if (lenght >= 3)
                    {
                        time = time.Insert(lenght - 2, ":");
                    }
                    else if (lenght == 2)
                    {
                        time = time.Insert(0, "0:");
                    }
                    else 
                    {
                        time = time.Insert(0, "0:0");
                    }

                    Console.Write($"{time} ");
                }

                Console.WriteLine();
            }

            void AdjustTimes()
            {
                for (int i = 0; i < times.Length; i++)
                {
                    times[i] = (times[i] + diff) % 2400;
                }
            }
            */

            #endregion

            // -----------------------------------------------
            #region Contoso_Pets_app
            /*

            // the animals array will store:
            string animalSpecies = "";
            string animalID = "";
            string animalAge = "";
            string animalPhysicalDescription = "";
            string animalPersonalityDescription = "";
            string animalNickname = "";
            string suggestedDonation = "";

            // variables that support data entry
            int maxPetsRows = 8;
            int petsInfoCols = 7;
            string? readResult;
            string menuSelection = "";
            int petAge = 0;
            decimal decimalDonation = 0.0m;

            // array used to store runtime data, there is no persisted(збережених) data
            string[,] arrAnimals = new string[maxPetsRows, petsInfoCols];

            #region  initial_animalsArr_data
            for (int i = 0; i < maxPetsRows; i++)
            {
                switch (i)
                {
                    case 0:
                    {
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female " 
                                    + "golden retriever weighing about 65 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have her belly rubbed " 
                                    + "and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "lola";
                        suggestedDonation = "85.00";
                        break;
                    }
                    case 1:
                    {
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever " 
                                    + "weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets " 
                                    + "you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "loki";
                        suggestedDonation = "49.99";
                        break;
                    }
                    case 2:
                    {
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "Puss";
                        suggestedDonation = "40.00";
                        break;
                    }
                    case 3:
                    {
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "?";
                        animalPhysicalDescription = "tbd";
                        animalPersonalityDescription = "tbd";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;
                    }
                    default:
                    {
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;
                    }
                }

                arrAnimals[i, 0] = "ID #: " + animalID;
                arrAnimals[i, 1] = "Species: " + animalSpecies;
                arrAnimals[i, 2] = "Age: " + animalAge;
                arrAnimals[i, 3] = "Nickname: " + animalNickname;
                arrAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                arrAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

                if (!decimal.TryParse(suggestedDonation, out decimalDonation)) {
                    decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
                }
                arrAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
            }
            #endregion

            do 
            {
                Console.Clear();
                Console.WriteLine("\n------ Welcome to the Contoso PetFriends app ------" );

                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("1. List all of our current pet information");
                Console.WriteLine("2. Add a new animal friend to the ourAnimals array");
                Console.WriteLine("3. Ensure animal ages and physical " 
                                    + "\n   descriptions are complete");
                Console.WriteLine("4. Ensure animal nicknames and personality" 
                                    + "\n    descriptions are complete");
                Console.WriteLine("5. Edit an animal’s age");
                Console.WriteLine("6. Edit an animal’s personality description");
                Console.WriteLine("7. Display all cats with a specified characteristic");
                Console.WriteLine("8. Display all dogs with a specified characteristic");
                Console.WriteLine("9. Exit Contoso PetFriends application");
                Console.WriteLine("---------------------------------------------------");
                Console.Write("Enter your selection number: ");
                readResult = Console.ReadLine();
                
                if (readResult != null)
                {
                    menuSelection = readResult.ToLower();
                }

                switch (readResult)
                {
                    case "1":
                    {
                        // List all of our current pets information
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: List all current pets");
                        Console.WriteLine("---------------------------------------------------");
                        
                        for (int i = 0; i < maxPetsRows; i++)
                        {
                            if (arrAnimals[i, 0] != "ID #: ")
                            {
                                Console.WriteLine();
                                for (int j = 0; j < petsInfoCols; j++)
                                {
                                    Console.WriteLine(arrAnimals[i, j]);
                                }
                            }
                        }

                        Console.WriteLine("\n---------------------------------------------------");
                        Console.Write("Press the Enter key to continue ");
                        readResult = Console.ReadLine();
                        
                        break;
                    }

                    case "2":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Add a new animal");
                        Console.WriteLine("---------------------------------------------------\n");
                        
                        string anotherPet = "y";
                        int petsCount = 0;
                        
                        
                        // This code will loop through the ourAnimals array 
                        // checking for assigned data. When it finds an animal 
                        // with data assigned, it increments petCounter.
                        
                        for (int i = 0; i < maxPetsRows; i++)
                        {
                            if (arrAnimals[i, 0] != "ID #: ")
                            {
                                petsCount += 1;
                            }
                        }

                        if (petsCount < maxPetsRows)
                        {
                            Console.WriteLine($"We currently have {petsCount} pets that need homes. " 
                                            + $"\nWe can manage {(maxPetsRows - petsCount)} more.");
                        }

                        while (anotherPet == "y" && petsCount < maxPetsRows)
                        {
                            bool validEntry = false;

                            do
                            {
                                Console.Write("\n\rEnter 'dog' or 'cat' to begin a new entry: ");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalSpecies = readResult.ToLower();
                                    if (animalSpecies != "dog" && animalSpecies != "cat")
                                    {
                                        validEntry = false;
                                    }
                                    else 
                                    {
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);

                            animalID = animalSpecies.Substring(0, 1) + (petsCount + 1).ToString();

                            do 
                            {
                                int age;
                                Console.Write("Enter the pet's age or enter ? if unknown: ");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalAge = readResult;
                                    if (animalAge != "?")
                                    {
                                        validEntry = int.TryParse(animalAge, out age); 
                                    }
                                    else 
                                    {
                                        validEntry = true;
                                    }
                                }
                            } while (validEntry == false);

                            do 
                            {
                                Console.WriteLine("Enter a physical description of the pet");
                                Console.Write("*size, *color, *gender, *weight, *housebroken: ");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalPhysicalDescription = readResult.ToLower();
                                    if (animalPhysicalDescription == "")
                                    {
                                        animalPhysicalDescription = "tbd";
                                    }
                                }
                            } while (animalPhysicalDescription == "");

                            do 
                            {
                                Console.WriteLine("Enter a description of the pet's personality");
                                Console.Write("*likes or dislikes, *tricks, *energy level: ");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalPersonalityDescription = readResult.ToLower();
                                    if (animalPersonalityDescription == "")
                                    {
                                        animalPersonalityDescription = "tbd";
                                    }
                                }
                            } while (animalPersonalityDescription == "");

                            do 
                            {
                                Console.Write("Enter a nickname for the pet: ");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    animalNickname = readResult.ToLower();
                                    if (animalNickname == "")
                                    {
                                        animalNickname = "";
                                    }
                                }
                            } while (animalNickname == "");

                            arrAnimals[petsCount, 0] = "ID #: " + animalID;
                            arrAnimals[petsCount, 1] = "Species: " + animalSpecies;
                            arrAnimals[petsCount, 2] = "Age: " + animalAge;
                            arrAnimals[petsCount, 3] = "Nickname: " + animalNickname;
                            arrAnimals[petsCount, 4] = "Physical description: " + animalPhysicalDescription;
                            arrAnimals[petsCount, 5] = "Personality: " + animalPersonalityDescription;

                            petsCount++;

                            if (petsCount < maxPetsRows)
                            {
                                do 
                                {
                                    Console.Write("Do you want to enter info for another pet (y/n): ");    
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        anotherPet = readResult.ToLower();
                                    }
                                } while (anotherPet != "y" && anotherPet != "n");
                            }
                        }

                        if (petsCount >= maxPetsRows)
                        {
                            Console.WriteLine(" ---------------------------------------------------");
                            Console.WriteLine("We've reached limit number of pets we can manage.");
                            Console.Write("Press the Enter key to continue ");
                            readResult = Console.ReadLine();
                        }

                        break;
                    }

                    case "3":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Animal ages and physical description");
                        Console.WriteLine("---------------------------------------------------\n");

                        string? petID;
                        int petIndex = 0;
                        bool validEntry = false;
                        bool quitEntry = false;

                        do 
                        {
                            Console.Write("Quit by 'q' / Select pet by ID (c/d + num): ");
                            petID = Console.ReadLine();

                            if (petID != null)
                            {
                                if (petID.ToLower() == "q")
                                {
                                    quitEntry = true;
                                    break;
                                }
                                else 
                                {
                                    for (int i = 0; i < maxPetsRows; i++)
                                    {
                                        if (arrAnimals[i, 0] == "ID #: " + petID)
                                        {
                                            Console.WriteLine("\n----- Pet found! -----");
                                            petIndex = i;
                                            validEntry = true;
                                            break;
                                        }
                                    }
                                    if (!validEntry)
                                    {
                                        Console.WriteLine("\n--- There's no pet with such an ID ---\n");
                                    }
                                }
                            }
                        } while (!validEntry && !quitEntry);

                        if (quitEntry)
                        {
                            Console.WriteLine("Returning to main menu..");
                            break;
                        }

                        if (validEntry)
                        {
                            Console.WriteLine("Information about:");
                            for (int col = 0; col < petsInfoCols; col++)
                            {
                                Console.WriteLine($"{arrAnimals[petIndex, col]}");
                            }

                            if (arrAnimals[petIndex, 2] == "Age: ?")
                            {
                                bool validAge = false;
                                do
                                {
                                    Console.Write($"\nEnter age for{arrAnimals[petIndex, 0]}: ");
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        animalAge = readResult;
                                        validAge = int.TryParse(animalAge, out petAge);
                                        if (validAge)
                                        {
                                            arrAnimals[petIndex, 2] = "Age: " + petAge.ToString();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid age. Please enter a valid number.");
                                        }
                                    }
                                } while (!validAge);
                            }
                            
                            if (arrAnimals[petIndex, 4] == "Physical description: tbd")
                            {
                                bool validDescription = false;
                                do
                                {
                                    Console.WriteLine("Enter a physical description of the pet");
                                    Console.Write("*size, *color, *gender, *weight, *housebroken: ");
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        animalPhysicalDescription = readResult.ToLower();
                                        if (animalPhysicalDescription != "")
                                        {
                                            validDescription = true;
                                            arrAnimals[petIndex, 4] = "Physical description: " + animalPhysicalDescription;
                                        }
                                        else 
                                        {
                                            validDescription = false;
                                            Console.WriteLine("Physical description cannot be empty.");
                                        }
                                    }
                                } while (!validDescription);
                            }

                            Console.WriteLine("\nUpdated pet Information:");
                            for (int col = 0; col < petsInfoCols; col++)
                            {
                                Console.WriteLine($"{arrAnimals[petIndex, col]}");
                            }
                        }

                        Console.WriteLine("\n\rAge and physical description fields are complete for all of our friends");
                        Console.Write("Press Enter to return to the main menu ");
                        Console.ReadLine();

                        break;
                    }
                    
                    case "4":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Animal nickname and personality description");
                        Console.WriteLine("---------------------------------------------------\n");

                        string? petID;
                        int petIndex = 0;
                        bool validEntry = false;
                        bool quitEntry = false;

                        do 
                        {
                            Console.Write("Quit by 'q' / Select pet by ID (c/d + num): ");
                            petID = Console.ReadLine();

                            if (petID != null)
                            {
                                if (petID.ToLower() == "q")
                                {
                                    quitEntry = true;
                                    break;
                                }
                                else
                                {
                                    for (int i = 0; i < maxPetsRows; i++)
                                    {
                                        if (arrAnimals[i, 0] == "ID #: " + petID)
                                        {
                                            Console.WriteLine("\n----- Pet found! -----");
                                            petIndex = i;
                                            validEntry = true;
                                            break;
                                        }
                                    }
                                    if (!validEntry)
                                    {
                                        Console.WriteLine("\n--- There's no pet with such an ID ---\n");
                                    }
                                }
                            }

                        } while (!validEntry && !quitEntry);
                        
                        if (quitEntry)
                        {
                            Console.WriteLine("Returning to main menu..");
                            break;
                        }

                        if (validEntry)
                        {
                            Console.WriteLine("Information about:");
                            for (int col = 0; col < petsInfoCols; col++)
                            {
                                Console.WriteLine($"{arrAnimals[petIndex, col]}");
                            }

                            if (arrAnimals[petIndex, 3] == "Nickname: ") // nickname
                            {
                                bool validNickname = false;
                                do
                                {
                                    Console.Write($"Enter nickname for{arrAnimals[petIndex, 0]}: ");
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        animalNickname = readResult.ToLower();
                                        if (animalNickname != "")
                                        {
                                            validNickname = true;
                                            arrAnimals[petIndex, 3] = "Nickname: " + animalNickname;
                                        }
                                        else
                                        {
                                            validNickname = false;
                                            Console.WriteLine("Nickname cannot be empty.");
                                        }
                                    }
                                } while (!validNickname);
                            }

                            if (arrAnimals[petIndex, 5] == "Personality: tbd") // personality description
                            {
                                bool validPersonality = false;
                                do
                                {
                                    Console.WriteLine($"Enter a description of the pet's personality for {arrAnimals[petIndex, 0]}");
                                    Console.Write("*likes or dislikes, *tricks, *energy level: ");
                                    readResult = Console.ReadLine();
                                    if (readResult != null)
                                    {
                                        animalPersonalityDescription = readResult.ToLower();
                                        if (animalPersonalityDescription != "")
                                        {
                                            validPersonality = true;
                                            arrAnimals[petIndex, 5] = "Personality: " + animalPersonalityDescription;
                                        }
                                        else
                                        {
                                            validPersonality = false;
                                            Console.WriteLine("Personality description cannot be empty.");
                                        }
                                    }
                                } while (!validPersonality);
                            }

                            Console.WriteLine("\nUpdated pet Information:");
                            for (int col = 0; col < petsInfoCols; col++)
                            {
                                Console.WriteLine($"{arrAnimals[petIndex, col]}");
                            }
                        }

                        Console.WriteLine("\nNickname and personality description fields have been completed");
                        Console.Write("Press Enter to return to the main menu ");
                        Console.ReadLine();

                        break;
                    }
                    
                    case "5":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Edit an animal’s age");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("No functionality yet, press any key to continue!");
                        Console.WriteLine("Quiting..\n\n");
                        break;
                    }
                    
                    case "6":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Edit an animal’s personality description");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("No functionality yet, press any key to continue!");
                        Console.WriteLine("Quiting..\n\n");
                        break;
                    }
                    
                    case "7":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Cats with a specified characteristic");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("No functionality yet, press any key to continue!");
                        Console.WriteLine("Quiting..\n\n");
                        break;
                    }
                    
                    // _________________ Here is pretty cool ANIMATION for searching ___________________
                    case "8":
                    {
                        // Display all dogs with a specified characteristic
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: Dogs with specified characteristic");
                        Console.WriteLine("---------------------------------------------------");

                        string dogCharacteristicUserInput = "";

                        while (dogCharacteristicUserInput == "")
                        {
                            Console.Write("Enter dog characteristics to search for separated by commas: ");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                dogCharacteristicUserInput = readResult.ToLower();
                            }
                        }

                        string[] dogSearches = dogCharacteristicUserInput.Split(",");
                        // trim leading and trailing spaces from each search term
                        for (int i = 0; i < dogSearches.Length; i++) 
                        {
                            dogSearches[i] = dogSearches[i].Trim();
                        }

                        Array.Sort(dogSearches);

                        // #4 update to "rotating" animation with countdown
                        string[] searchingIcons = {" |", " /", "--", " \\", " *"};

                        string dogDescription = "";
                        bool matchesAnyDog = false;

                        for (int i = 0; i < maxPetsRows; i++)
                        {
                            if (arrAnimals[i, 1].Contains("dog"))
                            {
                                dogDescription = arrAnimals[i, 4] 
                                        + "\n" + arrAnimals[i, 5]; 

                                bool matchesCurrentDog = false;

                                foreach (string term in dogSearches)
                                {
                                    if (term != null && term.Trim() != "")
                                    {
                                        for (int j = 2; j > -1; j--)
                                        {
                                            // countdown ANIMATION 
                                            foreach (string icon in searchingIcons)
                                            {
                                                Console.Write($"\n\rSearching our dog {arrAnimals[i, 3]}" 
                                                + $" for {term.Trim()} {icon} {j.ToString()}");
                                                
                                                Thread.Sleep(100); // затримка для демонстрації прогресу
                                            }

                                            // видаляю попередній вивід, переміщуючи каретку на початок рядка і очищаючи рядок
                                            // Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
                                            Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                                        }
                                
                                        if (dogDescription.Contains(" " + term.Trim() + " "))
                                        {
                                            Console.WriteLine($"\n\nOur dog  with {arrAnimals[i, 3]} matches your search for {term.Trim()}");
                                            Console.WriteLine("---------------------------------------------------");
                        
                                            matchesCurrentDog = true;
                                            matchesAnyDog = true;
                                        }
                                    }
                                }

                                // if the current dog is match, display the dog's info
                                if (matchesCurrentDog)
                                {
                                    Console.WriteLine($"\r{arrAnimals[i, 3]} ({arrAnimals[i, 0]})" 
                                                    + $"{dogDescription}");
                                }
                            }
                        }

                        if (!matchesAnyDog) 
                        {
                            Console.WriteLine("\n--- None of our dogs are a match found for: " 
                                            + dogCharacteristicUserInput + " ---");
                        }

                        Console.WriteLine("\n---------------------------------------------------");
                        Console.Write("Press any key to continue ");
                        readResult = Console.ReadLine();
                        break;
                    }
                    
                    case "9":
                    {
                        Console.WriteLine($"\n\n-- Menu option {menuSelection}: exit application");
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Thank you for using Contoso PetFriends application!");
                        Console.WriteLine("Quiting..\n\n");
                        break;
                    }
                    
                    default:
                    {
                        break;
                    }
                }
            } while (menuSelection != "9");
            




            */
            #endregion
            
            
            #region School_app
            /*
            int examAssignments = 5;

            int[] sophyaGrades = { 80, 86, 87, 98, 100, 94, 90 };
            int[] andrewGrades = { 92, 98, 91, 96, 90, 100, 99 };
            int[] emmaGrades = { 92, 89, 81, 96, 90, 89 };
            int[] loganGrades = { 50, 65, 67, 58, 96, 81, 91 };

            string[] studentsNames = { "Sophia", "Andrew", "Emma", "Logan"};

            int[] studentGrades = new int[10];

            string currentStudentLetterGrade;

            Console.Clear();
            Console.Write("\nStudent\t\tExam Score\tOverall Grade\tExtra Credit\n");
            Console.WriteLine("------------------------------------------------------------");
            
            
            // The outer foreach loop is used to:
            // - iterate through student names 
            // - assign a student's grades to the studentScores array
            // - calculate exam and extra credit sums (inner foreach loop)
            // - calculate numeric and letter grade
            // - write the score report information
            
            foreach (var name in studentsNames)
            {
                string currentStudent = name;

                if (currentStudent == "Sophia")
                    studentGrades = sophyaGrades;

                else if (currentStudent == "Andrew")
                    studentGrades = andrewGrades;

                else if (currentStudent == "Emma")
                    studentGrades = emmaGrades;
    
                else if (currentStudent == "Logan")
                    studentGrades = loganGrades;
                else
                    continue;

                int gradedAssignments = 0;
                int gradedExtraCreditAssignments = 0;

                int sumExamScores = 0;
                int sumExtraCreditScores = 0;

                decimal currentStudentGrade = 0;
                decimal currentStudentExamScore = 0;
                decimal currentStudentExtraCreditScore = 0;

                 
                // the inner foreach loop: 
                // - sums the exam and extra credit scores
                // - counts the extra credit assignments
                
                foreach (var grade in studentGrades)
                {
                    gradedAssignments++;

                    if (gradedAssignments <= examAssignments)
                    {
                        sumExamScores = sumExamScores + grade;
                    }
                    else 
                    {
                        gradedExtraCreditAssignments++;
                        sumExtraCreditScores += grade;
                    }
                }

                currentStudentExamScore = (decimal)sumExamScores / examAssignments;
                currentStudentExtraCreditScore = (decimal)sumExtraCreditScores 
                                                / gradedExtraCreditAssignments;
                
                currentStudentGrade = (decimal)(sumExamScores 
                + (sumExtraCreditScores / 10)) / examAssignments;
                
                if (currentStudentGrade >= 97)
                    currentStudentLetterGrade = "A+";
                
                else if (currentStudentGrade >= 93)
                    currentStudentLetterGrade = "A";

                else if (currentStudentGrade >= 90)
                    currentStudentLetterGrade = "A-";

                else if (currentStudentGrade >= 87)
                    currentStudentLetterGrade = "B+";

                else if (currentStudentGrade >= 83)
                    currentStudentLetterGrade = "B";

                else if (currentStudentGrade >= 80)
                    currentStudentLetterGrade = "B-";

                else if (currentStudentGrade >= 77)
                    currentStudentLetterGrade = "C+";

                else if (currentStudentGrade >= 73)
                    currentStudentLetterGrade = "C";

                else if (currentStudentGrade >= 70)
                    currentStudentLetterGrade = "C-";

                else if (currentStudentGrade >= 67)
                    currentStudentLetterGrade = "D+";

                else if (currentStudentGrade >= 63)
                    currentStudentLetterGrade = "D";

                else if (currentStudentGrade >= 60)
                    currentStudentLetterGrade = "D-";

                else 
                    currentStudentLetterGrade = "F";

                Console.WriteLine($"{currentStudent}:" + 
                                $"\t\t{currentStudentExamScore}" + 
                                $"\t\t{currentStudentGrade}" + 
                                $"\t{currentStudentLetterGrade}" + 
                                $"\t{currentStudentExtraCreditScore}" + 
                                $"({(((decimal)sumExtraCreditScores / 10) / examAssignments)} pts)");    
            }

            Console.WriteLine("------------------------------------------------------------");
            Console.Write("\n\t\t\t\t  Press Enter to continue ");
            Console.ReadLine();
            */
            #endregion

            #region practice_modul_4

            // challenge: extract, replace, and remove data from an input string
            /*
            const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

            string quantity = "";
            string output = "";

            // Your work here
            const string frontSpan = "<span>";
            const string backSpan = "</span>";
        
            int frontSpanPosition = input.IndexOf(frontSpan) + frontSpan.Length;
            int backSpanPosition = input.IndexOf(backSpan);
            int substringLength = backSpanPosition - frontSpanPosition;

            quantity = input.Substring(frontSpanPosition, substringLength);

            const string frontDiv = "<div>";
            const string backDiv = "</div>";
            
            output = input;

            int openDiv = output.IndexOf(frontDiv);
            output = output.Remove(openDiv, frontDiv.Length);

            int closeDiv = output.IndexOf(backDiv);
            output = output.Remove(closeDiv, backDiv.Length);

            Console.WriteLine("Quantity: " + quantity);
            Console.WriteLine("Output: " + output.Replace("&trade;", "&reg;"));
            */

            // Remove   |  Replace
            /*
            string data = "12345John Smith          5000  3  ";
            string message = "This--is--ex-amp-le--da-ta";
            
            // from index 5 + 20chars data'll be deleted
            // The Remove() method works similarly to the Substring() method
            string updatedData = data.Remove(5, 20);

            message = message.Replace("--", " ");
            message = message.Replace("-", "");
            
            Console.WriteLine(updatedData);
            Console.WriteLine(message);
            */
            
            // IndexOfAny ~~~
            /*
            string message = "(What if) I have [different symbols] but every " 
                            + "{open symbol} needs a [matching closing symbol]?";

            // The IndexOfAny() helper method requires a char array of characters. 
            // You want to look for:
            char[] openSymbols = { '[', '{', '('};

            // You'll use a slightly different technique for iterating through 
            // the characters in the string. This time, use the closing 
            // position of the previous iteration as the starting index for the 
            //next open symbol. So, you need to initialize the closingPosition 
            // variable to zero:
            int closingPosition = 0;

            while (true)
            {
                int openingPosition = message.IndexOfAny(openSymbols, closingPosition);

                if (openingPosition == -1) break;

                string currentSymbol = message.Substring(openingPosition, 1);

                // Now  find the matching closing symbol
                char matchingSymbol = ' ';

                switch (currentSymbol)
                {
                    case "[":
                        matchingSymbol = ']';
                        break;
                    case "{":
                        matchingSymbol = '}';
                        break;
                    case "(":
                        matchingSymbol = ')';
                        break;
                }

                // To find the closingPosition, use an overload of the IndexOf method to specify 
                // that the search for the matchingSymbol should start at the openingPosition in the string. 
                openingPosition += 1;
                closingPosition = message.IndexOf(matchingSymbol, openingPosition);

                // Finally, use the techniques you've already learned to display the sub-string:
                int length = closingPosition - openingPosition;
                Console.WriteLine(message.Substring(openingPosition, length));
            }
            */

            /*
            string message = "Help (find) the {opening symbols}";
            Console.WriteLine($"Searching THIS Message: {message}");

            char[] openSymbols = { '[', '{', '('};
            int startPosition = 5; // wth
            int openingPosition = message.IndexOfAny(openSymbols);

            Console.WriteLine($"Found without using start position: {message.Substring(openingPosition)}");

            openingPosition = message.IndexOfAny(openSymbols, startPosition);
            Console.WriteLine($"Found with using start position: {startPosition}: {message.Substring(openingPosition)}");
            */

            // LastIndexOf
            /*
            string message = "(What if) I am (only interested) in the last (set of parentheses)?";
            
            while (true)
            {
                int openingPosition = message.IndexOf('(');
                if (openingPosition == -1) break;

                openingPosition++;

                int closingPosition = message.IndexOf(')');
                int length = closingPosition - openingPosition;
                Console.WriteLine(message.Substring(openingPosition, length));

                message = message.Substring(closingPosition + 1);
            }
            */

            // IndexOf   |   Substring
            /*
            string message = "Find what inside ((((student of computer science))))";

            const string frontBraces = "((((";
            const string backBraces = "))))";

            int openingPosition = message.IndexOf(frontBraces);
            openingPosition += frontBraces.Length;

            int closingPosition = message.IndexOf(backBraces);

            int length = closingPosition - openingPosition;

            Console.WriteLine(message.Substring(openingPosition, length));
            */

            // challenge: strings interpolation 
            /*
            string customerName = "Ms. Barros";

            string currentProduct = "Magic Yield";
            int currentShares = 2975000;
            decimal currentReturn = 0.1275m;
            decimal currentProfit = 55000000.0m;

            string newProduct = "Glorious Future";
            decimal newReturn = 0.13125m;
            decimal newProfit = 63000000.0m;

            // ***Your logic here
            string completeMessage = "";

            string firstSentence = $"\nAs a customer of our {currentProduct} offering " 
                                + "we are excited to tell you about a new financial " 
                                + "product that would dramatically increase your return.";

            string secondSentence = $"\n\nCurrently, you own {currentShares:N2} shares at a return of {currentReturn:P2}.";

            string thirdSentence = $"\n\nOur new product, {newProduct} offers a return of {newReturn:P2}. " 
                                + $"Given your current volume, your potential profit would be {newProfit:C}.";
            
            string fourthSentence = "\n\nHere's a quick comparison:\n";

            string currentReturnStr = $"{currentReturn:P2}";
            string currentProfitStr = $"{currentProfit:C}";
            string newReturnStr = $"{newReturn:P2}";
            string newProfitStr = $"{newProfit:C}";

            // possible solution:
            // String.Format("{0:P}", currentReturn).PadRight(10);
            // String.Format("{0:C}", currentProfit).PadRight(20);
            // etc

            string fifthSentence = currentProduct.PadRight(20);
            fifthSentence += currentReturnStr.PadRight(10);
            fifthSentence += currentProfitStr.PadRight(20);
            fifthSentence += "\n";
            fifthSentence += newProduct.PadRight(20);
            fifthSentence += newReturnStr.PadRight(10);
            fifthSentence += newProfitStr.PadRight(20);

            completeMessage = string.Format("\n\nDear {0}, {1} {2} {3} {4}\n{5}", 
                                                customerName, 
                                                firstSentence, 
                                                secondSentence,
                                                thirdSentence,
                                                fourthSentence,
                                                fifthSentence);


            Console.WriteLine(completeMessage);
            */

            // paddings
            /*
            string paymentID = "789C";
            string payeeName = "Mr. Obrey Graham";
            string paymentAmmount = "$5,000.00";

            var formattedLine = paymentID.PadRight(6); // from 1 through 6
            formattedLine += payeeName.PadRight(24); // from 7 through 30
            formattedLine += paymentAmmount.PadRight(10); // in columns 31 through 40

            Console.WriteLine(formattedLine);
            */

            // composite formatting
            /*
            string first = "Hello";
            string second = "World";
            string result = string.Format("{0} {1}!", first, second);
            Console.WriteLine(result);

            // ----------> interesting feature with formatting
            decimal price_1 = 123.45m;
            int discount = 50;
            Console.WriteLine($"Price: {price_1:C} (Save {discount:C})");

            decimal measurement = 122333444.55555m;
            Console.WriteLine($"Measurement: {measurement:N} units");

            decimal tax = .23456m;
            Console.WriteLine($"Tax rate: {tax:P2}");

            // combine all
            decimal price = 67.55m;
            decimal salePrice = 59.99m;

            string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", 
                                                (price - salePrice), price);
            
            yourDiscount += $"A discount of {((price - salePrice) / price):P2}!"; // inserted
            Console.WriteLine(yourDiscount);
            */

            // challenge: sort orders and find an errors
            /*
            string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
            string[] orders = orderStream.Split(',');
            Array.Sort(orders);

            foreach (var order in orders)
            {
                if (order.Length == 4)
                {
                    Console.WriteLine(order);
                }
                else
                {
                    Console.WriteLine(order + "\t - Error");
                }
            }
            */

            // challenge: reverse words in a sentence
            /*
            string pangram = "The quick brown fox jumps over the lazy dog";
            string[] words = pangram.Split(' ');
            string reversed = "";
            
            foreach(var word in words)
            {
                char[] currentWord = word.ToCharArray();
                Array.Reverse(currentWord);
                string reversedWord = new string(currentWord);

                reversed += reversedWord + " ";
            }

            reversed = reversed.Trim();

            Console.WriteLine(reversed);
            */

            // firecamp solution:
            /*
            string pangram = "The quick brown fox jumps over the lazy dog";

            // Step 1
            string[] message = pangram.Split(' ');

            //Step 2
            string[] newMessage = new string[message.Length];

            // Step 3
            for (int i = 0; i < message.Length; i++)
            {
                char[] letters = message[i].ToCharArray();
                Array.Reverse(letters);
                newMessage[i] = new string(letters);
            }

            //Step 4
            string result = String.Join(" ", newMessage);
            Console.WriteLine(result);
            */

            // String methods Split() & Join()
            /*
            string value = "abc123";
            char[] valuesArray = value.ToCharArray();
            Array.Reverse(valuesArray);
            string result = String.Join(", ", valuesArray);
            System.Console.WriteLine(result);

            string[] items = result.Split(',');
            foreach (string item in items)
            {
                Console.Write(item);
            }
            */

            // Array methods Clear() & Resize()
            /*
            Console.WriteLine("\n--- Clear elements in array ---");
            string[] pallets = { "B14", "A11", "B12", "A13" };
            
            System.Console.Write("Innitial array: ");
            foreach (var s in pallets)
            {
                System.Console.Write(s + " ");
            }
            System.Console.WriteLine($"\nBefore: {pallets[0].ToLower()}");
            
            // starting at index 0 and clearing 2 elements.
            Array.Clear(pallets, 0, 2);
            Console.WriteLine($"Clearing 2 elements, count array lenght: {pallets.Length}");
            Console.Write("Elements: ");
            foreach (var pallet in pallets)
            {
                Console.Write(pallet + " ");
            }

            if (pallets[0] != null)
                Console.WriteLine($"\nAfter: {pallets[0].ToLower()}");
            else
                Console.WriteLine($"\nAfter: nullptr");

            Console.WriteLine("\n--- Resizing array ---");

            // resize to extend elements
            Array.Resize(ref pallets, 7);
            Console.WriteLine($"Pallets array length: {pallets.Length}");

            pallets[4] = "PAL4";
            pallets[5] = "PAL55";
            pallets[6] = "PAL666";

            Console.Write("New resized array: ");
            foreach (var p in pallets)
            {
                if (p != null)
                    Console.Write(p + " ");
                else 
                    Console.Write("nullptr ");
            }

            // resize to remove elements
            Array.Resize(ref pallets, 5);
            
            Console.Write("\nNew resized array: ");
            foreach (var p in pallets)
            {
                if (p != null)
                    Console.Write(p + " ");
                else 
                    Console.Write("nullptr ");
            }

            Console.WriteLine("\n");
            */

            // Array methods Sort() & Reverse()
            /*
            string[] pallets = { "B14", "A11", "B12", "A13" };
            
            Console.Write("Sorted: ");
            Array.Sort(pallets);
            foreach(var pallet in pallets)
            {
                Console.Write($" {pallet}");
            }

            Console.WriteLine();

            Console.Write("Reserved: ");
            Array.Reverse(pallets);
            foreach(var pallet in pallets)
            {
                Console.Write($" {pallet}");
            }
            */

            // TryParse exercise
            /*
            string[] values = { "12.3", "45", "ABC", "11", "DEF" };
            double totalSum = 0;
            string message = "";

            foreach (var value in values)
            {
                if (double.TryParse(value, out double num))
                {
                    totalSum += num;
                } 
                else
                {
                    message += value;
                }
            }

            System.Console.WriteLine("Message: " + message);
            System.Console.WriteLine("Total: " + totalSum);
            */
            #endregion

            #region practice_modul_3
            // user input walidation
            /*
            bool validInput = false;
            string position;

            do 
            {
                System.Console.Write("\nEnter ggg, hhh or jjj: ");
                position = Console.ReadLine();

                if (position.Trim().ToLower() == "ggg" 
                    || position.Trim().ToLower() == "hhh" 
                    || position.Trim().ToLower() =="jjj")
                {
                    validInput = true;
                    System.Console.WriteLine("Passed");
                }
                else 
                {
                    System.Console.WriteLine("Invalid input, try again.");
                }
            } while (!validInput);
            */

            /*
            string numInput;
            bool isParsed = false;
            int number = 0;
            bool validEntry = false;

            do 
            {
                Console.Write("\nEnter number from 5 to 10: ");
                numInput = Console.ReadLine();

                isParsed = int.TryParse(numInput, out number);

                if (isParsed && number >=5 && number <= 10)
                {
                    validEntry = true;
                }
                else if (isParsed && (number < 5 || number > 10))
                {
                    Console.WriteLine($"You entered {number}. Please enter a number between 5 and 10.");
                }
                else 
                {
                    Console.WriteLine("Invalid input, please enter again!");
                }

                // System.Console.WriteLine(number);

            } while (validEntry == false);
            */

            /*
            string? input;
            bool validEntry = false;

            do 
            {
                Console.Write("\nEnter string (at least 3 chars): ");
                input = Console.ReadLine();
                if (input != null)
                {
                    if (input.Length >= 3)
                    {
                        validEntry = true;
                    }
                    else 
                    {
                        Console.WriteLine("Invalid input, please enter again!");
                    }
                }
            } while (validEntry == false);
            */

            // challenge: hero monster game   |   do while
            /*
            Random hit = new Random();

            int heroHealthPoint = 10;
            int monsterHealthPoint = 10;

            int heroHit;
            int monsterHit;

            Console.WriteLine();

            Console.WriteLine($"Hero health: {heroHealthPoint}     |" +
                                    $"   Monster health: {monsterHealthPoint}");
            Console.WriteLine("------------------------------------------");
            
            do
            {
                if (monsterHealthPoint > 0)
                {
                    heroHit = hit.Next(1, 7);
                    monsterHealthPoint -= heroHit;

                    Console.WriteLine($"Hero damage: {heroHit}      |" +
                                    $"   Monster health: {monsterHealthPoint}");


                    if (monsterHealthPoint <= 0)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Hero wins :3\n\n");
                        break;
                    }

                    monsterHit = hit.Next(1, 8);
                    heroHealthPoint -= monsterHit;

                    Console.WriteLine($"Monster damage: {monsterHit}   |" +
                                    $"   Hero health: {heroHealthPoint}");
                }
                if (heroHealthPoint <= 0)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Monster win '^'\n");
                }

            } while (heroHealthPoint > 0);
            */

            // ------- ANOTHER SOLUTION -------
            /*
            do 
            {
                heroHit = hit.Next(1, 8);
                monsterHealthPoint -= heroHit;

                Console.WriteLine($"Hero damage: {heroHit}      |" +
                                    $"   Monster health: {monsterHealthPoint}");      

                if (monsterHealthPoint <= 0) continue;

                monsterHit = hit.Next(1, 9);
                heroHealthPoint -= monsterHit;

                Console.WriteLine($"Monster damage: {monsterHit}   |" +
                                    $"   Hero health: {heroHealthPoint}");          
            } while (heroHealthPoint > 0 
                && monsterHealthPoint > 0);

            Console.WriteLine("------------------------------------------");
            Console.WriteLine(heroHealthPoint > monsterHealthPoint ? "Hero wins :3\n\n" : "Monster win '^'\n");
            */

            // challenge: FizzBuzz   |   for loop   |   interview
            /*
            for (int i = 1; i <= 100; i++) 
            {
                bool fizz = i % 3 == 0;
                bool buzz = i % 5 == 0;

                if (fizz && buzz)
                {
                    Console.WriteLine($"{i} - FizzBuzz");
                }
                else if (fizz)
                {
                    Console.WriteLine($"{i} - Fizz");
                }
                if (buzz) 
                {
                    Console.WriteLine($"{i} - Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
                
            }
            */

            // strings~
            /*
            string test1 = " aaa";
            string test2 = "AAA "; 
            System.Console.WriteLine($"Special: {test1.Trim().Equals(test2.Trim(), 
                                    StringComparison.CurrentCultureIgnoreCase)}");
            */
            #endregion

            #region practice_module_2
            /*
            string str = "The quick brown fox jumps over the lazy dog.";

            char[] message = str.ToCharArray();
            Array.Reverse(message);
            
            int letterCount = 0;
            foreach (char letter in message) 
            { 
                if (letter == 'o') 
                { 
                    letterCount++; 
                } 
            }
            
            string newMessage = new String(message);
            
            Console.WriteLine(newMessage);
            Console.WriteLine($"'o' appears {letterCount} times.");
            */

            // first module
            /*
            Random random = new Random();
            int daysUntilExpiration = 1;// random.Next(12);
            int discountPercentage = 0;

            System.Console.WriteLine($"Days: {daysUntilExpiration}");

            if (daysUntilExpiration == 0)
            {
                System.Console.WriteLine("Your subscription has expired.");
            }
            else if (daysUntilExpiration == 1) 
            {
                Console.WriteLine("Your subscription expires within a day!");
                discountPercentage = 20;
            }
            else if (daysUntilExpiration <= 5)
            {
                discountPercentage = 10;
                System.Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
            }
            else if (daysUntilExpiration <= 10)
            {
                System.Console.WriteLine("Your subscription will expire soon. Renew now!");
            }

            if (discountPercentage > 0)
            {
                System.Console.WriteLine($"Renew now and save {discountPercentage}%");
            }
            */

            // random dice
            /*
            Random dice = new();

            int firstRoll = dice.Next(1, 7);
            int secondRoll = dice.Next(1, 7);
            int thirdRoll = dice.Next(1, 7);

            int total = firstRoll + secondRoll + thirdRoll;

            Console.WriteLine($"\nFirst roll: {firstRoll}");
            Console.WriteLine($"Second roll: {secondRoll}");
            Console.WriteLine($"Third roll: {thirdRoll}");
            
            Console.WriteLine($"\nTotal sum: {firstRoll} + {secondRoll} + {thirdRoll} = {total}\n");

            if ((firstRoll == secondRoll) 
                || (secondRoll == thirdRoll) 
                || (firstRoll == thirdRoll))
            {
                if ((firstRoll == secondRoll) 
                    && (secondRoll == thirdRoll))
                {
                    System.Console.WriteLine("You rolled triples! +6 bonus to total!");
                    total += 6;
                } 
                else 
                {
                    System.Console.WriteLine("You rolled doubles! +2 bonus to total!");
                    total += 2;
                }
            }

            if (total >= 16)
            {
                System.Console.WriteLine("You win new car!\n");
            }
            else if (total >= 10)
            {
                System.Console.WriteLine("You win new laptop");
            }
            else if (total == 7)
            {
                System.Console.WriteLine("You win a trip!");
            }
            else 
            {
                System.Console.WriteLine("You win a kitten!\n");
            }
            */
            #endregion

            // DEAL WITH THAT TASK:
            
            /*
                The following code is one possible solution for challenge project 3 from the previous unit.

                The code uses a for statement for the outer loop because you cannot modify the value assigned 
                to a 'foreach iteration variable'. You could work around this by declaring an additional string
                variable inside the foreach loop, but then you would be adding unwanted complexity to your 
                code logic. In other words, using the iteration statement foreach (string myString in myStrings) 
                and then attempting to process the myString variable will generate a compilation error.

                The code uses a while statement for the inner loop because, depending on the value of the data 
                string, the code block may not be executed (when the string does not contain a period). You 
                should not use a do statement in situations where the iteration block may not need to be executed.
            */

            /*
            string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
            int stringCount = myStrings.Length;

            string myString = "";
            int periodLocation = 0;

            for (int i = 0; i < myStrings.Length; i++)
            {
                myString = myStrings[i];
                periodLocation = myString.IndexOf(".");

                string mySentence;

                // extract sentences from each string and display them one at a time
                while (periodLocation != -1) 
                {
                    // first sentence is the string value to the left of the period location
                    mySentence = myString.Remove(periodLocation);

                    // the remainder of myString is the string value to the right of the location
                    myString = myString.Substring(periodLocation + 1);

                    // remove any leading white-space from myString
                    myString = myString.TrimStart();

                    // update the comma location and increment the counter
                    periodLocation = myString.IndexOf(".");

                    Console.WriteLine(mySentence);
                }

                mySentence = myString.Trim();
                Console.WriteLine(mySentence);
            } 
            */
        }
    }
}