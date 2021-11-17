

/*
 * Дефинирайте клас Speciality, който да представя данните за специалностите един в университет. Нека класът съдържа полета за:  наименование на специалността (символен низ), брой жени (цяло число), брой мъже  (цяло число), среден успех за специалността  (реално число) и следните елементи:
•	Конструктор по подразбиране и конструктор с параметри;
•	Методи за достъп (setter, getter) до  полетата;
•	Метод за извеждане съдържанието на полетата на обект
•	Метод ОutputScore, който по въведено от потребителя наименование на специалност, извежда средния успех с думи (2-слаб, 3-среден, 4-добър, 5-мн.добър, 6-отличен)
•	Метод NumberStudents, който връща брой студенти в специалност, въведена от потребителя (брой студенти = брой мъже + брой жени)

В Main() декларирайте масив от n обекта от класа (3 <= n <= 20) и въведете конкретни стойности за полетата им. Тествайте създадените методи.
 */

//Helper -> Initialize array with random values

Speciality[] InitializeArray(int length)
{
    Random random = new Random();
    string[] specialties = { "CS", "Technology", "Networking", "SoC", "WebDevelopment", "DevOps" };

    Speciality[] array = new Speciality[length];
    for (int i = 0; i < length; ++i)
    {
        float randomScore = random.NextSingle()* 4 + 2 ;
        uint randomFemlaeStudents = (uint)random.Next(1, 420);
        uint randomMaleStudentsale = (uint)random.Next(1, 69);
        array[i] = new Speciality(specialties[random.Next(0, specialties.Length)], randomFemlaeStudents, randomMaleStudentsale, randomScore);
    }

    return array;
}

// 3 <= n <= 20    =>> From 3 to 20 =>> 17
Speciality[] specialities = InitializeArray(17);



// Could also do something like this
/*
int maxNum = 20, minNum = 3;
Speciality[] _specialities = new Speciality[maxNum - minNum];
for (int i = 0; i < _specialities.Length; i++)
{
    // Intiliaze them 
    _specialities[i] = new Speciality(...params) 
}
*/


class Speciality
{
    private string specialty;
    private uint femaleCount, maleCount;
    private float averageScore;
    public static int count = 0;


    public  Speciality()
    {
    }
    public Speciality(string specialty, uint femaleCount, uint maleCount, float averageScore)
    {
        this.specialty = specialty;
        this.femaleCount = femaleCount;
        this.maleCount = maleCount;
        this.averageScore = averageScore;
    }

    public float AverageScore { get => averageScore; set => averageScore = value > 2 || value < 6  ? value : averageScore; }
    public uint FemaleCount { get => femaleCount; set => femaleCount = value >  0 ? value:femaleCount; }
    public uint MaleCount { get => maleCount; set => maleCount = value > 0 ? value: maleCount; }
    public string Specialty { get => specialty ?? "Speciality not set"; set => specialty = value!="" ? value: "No speciality set"; }

    //Helper utility
    private string scoreToText(float score) 
    {
        return score switch
        {
            >= 2f and < 3f => "2-Bad",
            >= 3f and < 4f => "3-Poor",
            >= 4f and < 5f => "4-Fair",
            >= 5f and < 6f => "5-Good",
            6f => "6-Excellent",
            _ => "Value not set",
        };
    }

    public void OutputScore()
    {
        Console.WriteLine(this.scoreToText(this.averageScore));
    }

    // Not sure if this is what is desired
    public uint NumberStudents()
    {
        return  (uint)((int)maleCount + (int)femaleCount);
    }
    // Made a static method just in case
    public static uint NumberStudents(Speciality speciality)
    {
        return (uint)((int)speciality.FemaleCount + (int)speciality.FemaleCount);
    }
}