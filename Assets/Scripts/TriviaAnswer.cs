using System.Collections;
using System.Collections.Generic;

public class TriviaAnswer
{
    private int number;

    private int indexCorrectAnswer;

    public TriviaAnswer(int _number, int _indexCorrectAnswer)
    {
        number = _number;
        indexCorrectAnswer = _indexCorrectAnswer;
    }

    public int getNumber()
    {
        return number;
    }

    public int getIndexCorrectAnswer()
    {
        return indexCorrectAnswer;
    }

    public string toString()
    {
        return "number: " +
        number +
        ", indexCorrectAnswer: " +
        indexCorrectAnswer;
    }
}
