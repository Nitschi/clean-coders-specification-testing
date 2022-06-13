﻿namespace Bowling;

public class BowlingGame
{

    private int[] rolls = new int[21];
    private int currentRoll = 0;

    public void Roll(int pins)
    {
        rolls[currentRoll++] = pins;
    }

    public int Score()
    {
        int score = 0;
        int firstInFrame = 0;
        for (int frame = 0; frame < 10; frame++)
        {
            if (isStrike(firstInFrame))
            {
                score += 10 + nextTwoBallsForStrike(firstInFrame);
                firstInFrame++;
            }
            else if (isSpare(firstInFrame))
            {
                score += 10 + nextBallForSpare(firstInFrame);
                firstInFrame += 2;
            }
            else
            {
                score += twoBallsInFrame(firstInFrame);
                firstInFrame += 2;
            }
        }
        return score;
    }

    private int twoBallsInFrame(int firstInFrame)
    {
        return rolls[firstInFrame] + rolls[firstInFrame + 1];
    }

    private int nextBallForSpare(int firstInFrame)
    {
        return rolls[firstInFrame + 2];
    }

    private int nextTwoBallsForStrike(int firstInFrame)
    {
        return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
    }

    private bool isStrike(int firstInFrame)
    {
        return rolls[firstInFrame] == 10;
    }

    private bool isSpare(int firstInFrame)
    {
        return rolls[firstInFrame] + rolls[firstInFrame + 1] == 10;
    }

}
