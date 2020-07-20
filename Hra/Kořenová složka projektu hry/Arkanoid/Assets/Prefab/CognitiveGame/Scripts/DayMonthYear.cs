using System;

using Random = System.Random;
/**
 *
 * Trida dedi od ACogGame a zajistuje kognitivni minihru pro otazku na aktualni den/datum.
 *
 * 
 * */
public class DayMonthYear : ACogGame
{
   
    /**
     * Vytvori otazku minihry.
     */

    protected override void fillParam()
    {
        for (int i = 0; i < CognitiveGameManager.countOfLevel; i++)
        {
            level[i] = true;
        }


        mainT = "Zvol správně";
    }

/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
protected override string firstLevel()
{

return getDayInWeek();

}

/**
*Funkce pro vytvoreni minihry dane narocnosti
*/

protected override string secondLevel()
{
Random rand = new Random();
int r = rand.Next(2);
String res = "";
switch (r)
{
    case 0: res =getDayInWeek();
        break;
    case 1: res =getYear();
        break;

}

return res;

}
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/

protected override string thirthLevel()
{
Random rand = new Random();
int r = rand.Next(3);
String res = "";
switch (r)
{
    case 0: res =getDayInWeek();
        break;
    case 1: res =getYear();
        break;
    case 2: res =getMounth();
        break;
    
}

return res;
}
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/

protected override string fourthLevel()
{
Random rand = new Random();
int r = rand.Next(2);
String res = "";
switch (r)
{
    case 0: res =getDayInWeek();
        break;
    case 1: res =getDate();
        break;

}

return res;


}
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
protected override string fifthLevel()
{
return fourthLevel();
}
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
protected override string sixthLevel()
{
Random rand = new Random();
int r = rand.Next(2);
String res = "";
switch (r)
{
    case 0: res =getDayInWeek();
        break;
    case 1: res =getFullDate();
        break;

}

return res;
}
/**
*Funkce pro vytvoreni minihry dane narocnosti
*/
protected override string seventhLevel()
{
return sixthLevel();
}
/**
*Funkce vytvoreni minihry na otazku aktualniho dne
*/
private String getDayInWeek()
{
String right = getCzechDay(DateTime.Today.DayOfWeek.ToString());


Random rand = new Random();

if (rand.Next(2) == 0)
{
    leftT = right;
    rightT = getWrongDay(right);
    leftTrue = true;
}
else
{
    rightT = right;
    leftT = getWrongDay(right);
    leftTrue = false;
}

return "Dnešní den v týdnu je?";
}

/**
*Funkce pro vypsani dnu v cestine
*/

private String getCzechDay(String engDay)
{
switch (engDay)
{
    case "Monday": return "Pondělí";
    case "Tuesday": return "Úterý";
    case "Wednesday": return "Středa";
    case "Thursday": return "Čtvrtek";
    case "Friday": return "Pátek";
    case "Saturday": return "Sobota";
    case "Sunday": return "Neděle";
}

return engDay;
}

/**
*Funkce pro vytvoreni chybne odpovedi dnu
*/


private String getWrongDay(String day)
{
Random rand = new Random();

String answ = "";

do
{
    int temp = rand.Next(7);
    switch (temp)
    {
        case 0:
            answ = "Pondělí";
            break;
        case 1:
            answ = "Úterý";
            break;
        case 2:
            answ = "Středa";
            break;
        case 3:
            answ = "Čtvrtek";
            break;
        case 4:
            answ = "Pátek";
            break;
        case 5:
            answ = "Sobota";
            break;
        case 6:
            answ = "Neděle";
            break;
    }
} while (day.Equals(answ));


return answ;
}

/**
*Funkce pro vytvoreni minihry na otazku celeho aktualnih data
*/
private String getFullDate()
{
int day = DateTime.Today.Day;
int mounth = DateTime.Today.Month;
int year = DateTime.Today.Year;

Random rand = new Random();

String right = day + "."+getCzechMounth(mounth-1)+ "."+year;
String wrong="";

int wr = rand.Next(3);

switch (wr)
{
    case 0: wrong = rand.Next(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))+1 + "."+getCzechMounth(mounth-1) + "."+year;
        break;
    case 1:  wrong = day + "." + getWrongMonth(getCzechMounth(mounth-1))+ "."+year;
        break;
    case 2: wrong = day + "." + getCzechMounth(mounth - 1) + "." + (rand.Next(3) + 1 + year);
        break;
}

 

if (rand.Next(2) == 0)
{
    leftT = right;
    rightT = wrong;
    leftTrue = true;

}
else
{
    rightT = right;
    leftT = wrong;
    leftTrue = false;
}
return "Dnešní datum je?";

}
/**
 * Funkce pro vytvoreni minihry na otazku  aktualnih data
 */

private String getDate()
{
int day = DateTime.Today.Day;
int mounth = DateTime.Today.Month;

Random rand = new Random();

String right = day + "."+getCzechMounth(mounth-1);
String wrong;

if (rand.Next(2) == 0)
{
    wrong = rand.Next(DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))+1 + "."+getCzechMounth(mounth-1);
}
else
{
    wrong = day + "." + getWrongMonth(getCzechMounth(mounth-1));
}

if (rand.Next(2) == 0)
{
    leftT = right;
    rightT = wrong;
    leftTrue = true;

}
else
{
    rightT = right;
    leftT = wrong;
    leftTrue = false;
}
return "Dnešní datum je?";
}
/**
 *Funkce pro vytvoreni minihry na otazku jaky je rok
 * 
 */
private String getYear()
{
Random rand = new Random();
int mistake = rand.Next(3) + 1;

int right = DateTime.Today.Year;

if (rand.Next(2) == 0)
{
    mistake = mistake + right;
}
else
{
    mistake = right - mistake;
}

if (rand.Next(2) == 0)
{
    leftT = right + "";

    rightT = mistake + "";
    leftTrue = true;
}
else
{
    rightT = right + "";

    leftT = mistake + "";
    leftTrue = false;
}

return "Aktuální rok je?";
}

/**
 *Funkce pro vytvoreni minihry na otazku jaky je mesic
 * 
 */


private String getMounth()
{
String right = getCzechMounth(DateTime.Today.Month - 1);


Random rand = new Random();

if (rand.Next(2) == 0)
{
    leftT = right;
    rightT = getWrongMonth(right);
    leftTrue = true;
}
else
{
    rightT = right;
    leftT = getWrongMonth(right);
    leftTrue = false;
}

return "Aktuální měsíc v roce je?";
}

/**
 * Pro zjisteni ceskeho nazvu mesice
 */
private String getCzechMounth(int engMounth)
{
String answ = "";

switch (engMounth)
{
    case 0:
        answ = "Leden";
        break;
    case 1:
        answ = "Únor";
        break;
    case 2:
        answ = "Březen";
        break;
    case 3:
        answ = "Duben";
        break;
    case 4:
        answ = "Květen";
        break;
    case 5:
        answ = "Červen";
        break;
    case 6:
        answ = "Červenec";
        break;
    case 7:
        answ = "Srpen";
        break;
    case 8:
        answ = "Září";
        break;
    case 9:
        answ = "Říjen";
        break;
    case 10:
        answ = "Listopad";
        break;
    case 11:
        answ = "Prosinec";
        break;
}

return answ;
}
/**
 * Funkce pro vytvoreni spatne odpovedi mesice
 */
private String getWrongMonth(String month)
{
Random rand = new Random();

String answ = "";

do
{
    int temp = rand.Next(12);
    switch (temp)
    {
        case 0:
            answ = "Leden";
            break;
        case 1:
            answ = "Únor";
            break;
        case 2:
            answ = "Březen";
            break;
        case 3:
            answ = "Duben";
            break;
        case 4:
            answ = "Květen";
            break;
        case 5:
            answ = "Červen";
            break;
        case 6:
            answ = "Červenec";
            break;
        case 7:
            answ = "Srpen";
            break;
        case 8:
            answ = "Září";
            break;
        case 9:
            answ = "Říjen";
            break;
        case 10:
            answ = "Listopad";
            break;
        case 11:
            answ = "Prosinec";
            break;
    }
} while (month.Equals(answ));


return answ;
}
}