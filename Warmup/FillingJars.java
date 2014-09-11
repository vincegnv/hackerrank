//Animesh has N empty candy jars, numbered from 1 to N, with infinite capacity.
// He performs M operations. Each operation is described by 3 integers a, b and k.
// Here, a and b are indices of the jars, and k is the number of candies to be added inside each jar whose index lies 
// between a and b (both inclusive). Can you tell the average number of candies after M operations?
//
//        Input Format
//        The first line contains two integers N and M separated by a single space.
//        M lines follow. Each of the M lines contain three integers a, b and k separated by single space.
//
//        Output Format
//        A single line containing the average number of candies across N jars, rounded down to the nearest integer.
//
//        Note
//        Rounded down means finding the greatest integer which is less than or equal to given number.
//        Eg, 13.65 and 13.23 is rounded down to 13, while 12.98 is rounded down to 12.
//
//        Constraints
//        3 <= N <= 107
//        1 <= M <= 105
//        1 <= a <= b <= N
//        0 <= k <= 106
//
//        Sample Input #00
//
//        5 3
//        1 2 100
//        2 5 100
//        3 4 100
//        Sample Output #00
//
//        160
//        Explanation
//        Initially each of the jar contains 0 candies
//
//        0 0 0 0 0
//        First operation
//
//        100 100 0 0 0
//        Second operation
//
//        100 200 100 100 100
//        Third operation
//
//        100 200 200 200 100
//        Total = 800, Average = 800/5 = 160

package com.vincegnv.solution;

import java.math.BigInteger;
import java.util.*;

public class Solution {

    private static Scanner in;

    public static void main(String[] args) {
        in = new Scanner(System.in);

        int numberOfJars = in.nextInt();
        int operations = in.nextInt();
        in.nextLine();

        BigInteger totalCandies = BigInteger.ZERO;
        for(int i = 0; i < operations; i++){
            int a = in.nextInt();
            int b = in.nextInt();
            int candiesToAdd = in.nextInt();

            totalCandies = totalCandies.add(BigInteger.valueOf((long)(b-a+1)).multiply(BigInteger.valueOf((long)candiesToAdd)));
        }

        BigInteger averageCandies = totalCandies.divide(BigInteger.valueOf((long)numberOfJars));

        System.out.print(averageCandies);
    }



}
