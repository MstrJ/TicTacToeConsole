


internal class Program
{
    private static string Pokaztablica(string[] arr)
    {
        
        return $"TicTacToe\n___________\n {arr[0]} | {arr[1]} | {arr[2]} |\n___|___|___| \n {arr[3]} | {arr[4]} | {arr[5]} |\n___|___|___| \n {arr[6]} | {arr[7]} | {arr[8]} |\n___|___|___|";
    }

    private static void Main(string[] args)
    {
        string[] tablicaGry = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        bool[] poprawnoscTablicy = { true, true, true, true, true, true, true, true, true };

        string znak = "O";
        string number;
        bool trwanieGry = false;
        int iloscPolAktywnych = 9;
        bool loop1;
        bool loop2;

        Console.Clear();
        Console.WriteLine("Naciśnij 'enter' aby rozpoczać gre...");
        string dowolnyZnak = Console.ReadLine();
        if (dowolnyZnak != null) {
            trwanieGry = true;
            Console.Clear();
        }
        if (trwanieGry)
        {
            Console.WriteLine(Pokaztablica(tablicaGry));
            while (trwanieGry)
            {
                if (znak == "O")
                {
                    loop1 = true;
                    if (iloscPolAktywnych != 0)
                    {
                        while (loop1) // big brain
                        {
                            string x="";
                            // Gracz
                            if (Wynik(tablicaGry, "X").Contains("X"))
                            {
                                znak = Wynik(tablicaGry, "X");
                                trwanieGry = false;
                                loop1 = false;
                            }
                            else {
                            Console.WriteLine($"\nPodaj number: ");
                            x = Console.ReadLine();
                            }
                            number = x;
                            if (Wynik(tablicaGry, "X").Contains("X"))
                            {
                            }
                            if (NumberSearch(tablicaGry, poprawnoscTablicy, number, znak))
                            {
                                //Console.WriteLine("LOOP 1" + Pokaztablica(tablicaGry));
                                //Console.WriteLine(Wynik(tablicaGry, "O").Contains("O") + "()()()()");
                                if (Wynik(tablicaGry,"O").Contains("O"))
                                {
                                    znak = Wynik(tablicaGry, "O");
                                    loop1 = false;
                                    trwanieGry = false;
                                }
                                else {
                                loop1 = false;
                                iloscPolAktywnych--;
                                znak = "X";
                                }
                            }
                        }
                    }

                }
                else if (znak == "X")
                {
                    loop2 = true;
                    if (iloscPolAktywnych == 0 && !Wynik(tablicaGry, "O").Contains("O"))
                    {
                        //Console.WriteLine("bot remis");
                        znak = "REMIS";
                        trwanieGry = false; 
                    }
                    else if (iloscPolAktywnych != 0)
                    {
                        while (loop2)
                        {
                            // Ruch bota
                            Random rand = new Random();
                            int numberr = rand.Next(9) + 1;
                            number = numberr.ToString();

                            if (Wynik(tablicaGry, "O").Contains("O"))
                            {
                                trwanieGry = false;
                                loop2 = false;
                                znak = Wynik(tablicaGry, "O");
                            }
                            else if (NumberSearch(tablicaGry, poprawnoscTablicy, number, znak))
                            {
                                Console.Clear();
                                Console.WriteLine(Pokaztablica(tablicaGry));
                                Console.WriteLine($"\nBot wykonał ruch nr {number}");
                                if (Wynik(tablicaGry, "X").Contains("X"))
                                {
                                    znak = Wynik(tablicaGry, "X");
                                    loop2 = false;
                                    trwanieGry = false;
                                }
                                else {
                                loop2 = false;
                                iloscPolAktywnych--;
                                znak = "O";
                            }
                            }
                        }
                    }
                }

            }
        }
        if (trwanieGry == false)
        {
            Console.Clear();
            Console.WriteLine(Pokaztablica(tablicaGry));
            String ktoWygral = znak.Contains("O") || znak.Contains("X") ? "Wygrał" : "";
            Console.WriteLine($"\nKoniec gry | {ktoWygral} {znak} |");
        }

    }


    public static bool NumberSearch(string[] arr1, bool[] arr2, string number, string znak)
    {
        //Console.WriteLine(SprawdzaNumber(arr1, number));
        string n = SprawdzaNumber(arr1, number);
        if (n.Equals("powtorka")) 
        { 
            return false; 
        }
        int index = int.Parse(n) - 1;
        if (!arr2[index].Equals("X") && !arr2[index].Equals("O"))
        {
            arr1[index] = znak;
            arr2[index] = false;
            return true;
        }
        else
        {
            return false;
        }


    }
    public static string SprawdzaNumber(string[] arr, string number)
    {
        foreach (string item in arr)
        {
            if (item.Contains(number)) return item;
        }
        return "powtorka";
    }

    public static string Wynik(string[] arr, string znak)
    {
        string[] row1 = { arr[0], arr[1], arr[2] };
        string[] row2 = { arr[3], arr[4], arr[5] };
        string[] row3 = { arr[6], arr[7], arr[8] };

        if (row1[0] == znak && row1[1] == znak && row1[2] == znak) return znak;
        else if (row2[0] == znak && row2[1] == znak && row2[2] == znak) return znak;
        else if (row3[0] == znak && row3[1] == znak && row3[2] == znak) return znak;

        else if(row1[0] == znak && row2[0] == znak && row3[0] == znak) return znak;
        else if(row1[1] == znak && row2[1] == znak && row3[1] == znak) return znak;
        else if(row1[2] == znak && row2[2] == znak && row3[2] == znak) return znak;


        else if(row1[0] == znak && row2[1] == znak && row3[2] == znak) return znak;
        else if(row1[2] == znak && row2[1] == znak && row3[0] == znak) return znak;

        else return "nie";
    }
}