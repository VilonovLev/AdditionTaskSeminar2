// Игра угадайка. Программа загадывает случайное число. Пользователь его угадывает. 
// Если пользователь дает неправильный ответ, то программа сообщает,
// больше загаданное число или меньше. На отгадывание дается 3 попытки.

string lvlMess = "Выберите уровень сложности от 1 до 3:" + 
                 "\n1_lvl цифры от 0 -> 10" + 
                 "\n2_lvl цифры от 0 -> 20" +
                 "\n3_lvl цифры от 0 -> 30",
       errorMess = "Такого уровня пока нет :(",
       inputMess = "Введите число.",
       winMess = "Ура! Ты угадал! Подглядел наверное...",
       lossMess = "Ты проиграл... Возможно стоит упростить задачу...",
       resMess = "Если хочеш попробовать еще введи 1, если нет введи 0.",
       attemptMess = "Попыток осталось: ";
    
int lvlDifficulty,
    inputNum,
    randomNum = 0,
    attemptCount = 3;

bool flag = true;

while(true)
{
    while(flag)
    {   
        Output(lvlMess);
        lvlDifficulty = Convert.ToInt32(Console.ReadLine());
        if ((lvlDifficulty < 4) && (lvlDifficulty > 0))
        {
            randomNum = new Random().Next(0,10*lvlDifficulty + 1);
            flag = false;
            continue;
        }
        Output(errorMess);
    }

    Output(inputMess);
    Output(attemptMess);
    inputNum = Convert.ToInt32(Console.ReadLine());
    attemptCount--;

    if (inputNum == randomNum)
    {
        Output(winMess);
        if (Reset() == 0)
        {
            break;
        }   
    }
    else 
    {
        Miss(inputNum,randomNum);
    }
   
    if(attemptCount == 0)
    {
        Output(lossMess);
        if (Reset() == 0)
        {
            break;
        }   
    }
}

void Output(string line)
{
    if (line == attemptMess)
    {
        line = attemptMess + attemptCount; 
    }
    Console.WriteLine(line);
}

void Miss(int inp, int ran)
{
    if (inp > ran)
    {
        Output("Загаданное число меньше...");
    }
    else
    {
        Output("Загаданное число больше...");
    }
}

int Reset()
{
    Output(resMess);
        inputNum = Convert.ToInt32(Console.ReadLine());
        if (inputNum == 1)
        {
            flag = true;
            attemptCount = 3;
            return inputNum;
        }
        else
        {
            return inputNum;
        }
}




