package com.vincegnv.solution;

import java.io.*;
import java.util.*;
import java.text.*;
import java.math.*;
import java.util.regex.*;

public class Solution {

private static Scanner in;

    public static void main(String[] args) {
        in = new Scanner(System.in);

        int numberRocks = in.nextInt();

        start(numberRocks);

    }

    private static void start(int numberTestCases) {
        in.nextLine();
        String firstRock = in.nextLine();
        List<Character> result = getDistinctLetters(firstRock);
        for(int i = 0; i<numberTestCases - 1; i++){
            result = getCommonLetters(result, in.nextLine());
        }

        System.out.print(result.size());
    }

    static List<Character> getDistinctLetters(String rock){
        List<Character> rockList = new ArrayList<Character>();
        for(int i = 0; i<rock.length(); i++){
            if(!rockList.contains((Character)rock.charAt(i))){
                rockList.add(rock.charAt(i));
            }
        }
        return rockList;
    }

    static List<Character> getCommonLetters(List<Character> resultList, String rock){
        List<Character> rockList = getDistinctLetters(rock);

        for(Character c : resultList){
            if(!rockList.contains(c)){
                resultList.remove(c);
            }
        }
        return resultList;
    }

}
