﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC._2018
{
    class Day13
    {
        readonly string _input = @"                                                /-----------------------------------------------------------------\                                   
                                                |    /------------------------------\                             |                                   
       /----------------------------------------+----+------------------------------+----------------------------\|                                   
       |     /---------------------->-----------+----+--\     /---------------------+----------------------------++------------------------------\    
       |     |                             /----+----+--+-----+---------------------+----------------------------++-------\                      |    
       | /---+-----------------------------+----+----+--+-----+---------------------+--------------\             ||       |                      |    
       | | /-+-----------------------------+----+----+--+-----+----------------\  /-+--------------+-------------++-------+-----\                |    
       | | | |     /-----------------------+----+----+--+--\  |                |  | |             /+-------------++-------+-----+\               |    
       | | | |     |                       |    |    |  |  |  |                |  | |     /-------++-------<-----++-------+-----++--\            |    
   /---+-+-+-+-----+---------------\       |  /-+----+--+--+--+----------------+--+-+-----+-------++-------------++-------+-----++--+------------+\   
   |   | | | |     |               |      /+--+-+----+--+--+--+----------------+--+-+-----+-------++-------------++-------+-----++--+------------++--\
   |   | | | |     |               |      ||  | |   /+--+--+--+---------\ /----+--+-+-----+-------++-------------++--\    |     ||  |            ||  |
   |   | | | |     |               |      ||  | |   ||/-+--+--+---------+-+----+--+-+-----+-------++-------------++--+----+---\ ||  |            ||  |
   |   | | | |     |               |      ||  | |   |\+-+--+--+---------+-+----+--+-/     |       ||             ||  |    |   | ||  |            ||  |
   | /-+-+-+-+-----+---------------+------++--+-+---+-+\|  |  |         | |/---+--+-------+-------++-----------\ ||  |    |   | ||  |            ||  |
   | | | | | |     |  /----------\ |      ||  | |   | |||  |  |         | v|   |  |       |       ||           | ||  |    |   | ||  |            ||  |
   | | | | | |     | /+----------+\|      ||  | |   | |||  |  |        /+-++---+--+-------+-------++-----------+-++-\|    |   | ||  |            ||  |
   | | | | | \-----+-++----------+++------++--+-+---+-++/  |  |/-------++-++---+--+-------+-------++---\       | || ||    |   | ||  |            ||  |
   | | | | |     /-+-++----------+++------++--+-+---+-++---+--++-------++-++---+--+---\   |       ||   |       | || ||    |   | ||  |            ||  |
   | | | | |     | | ||          |||      ||  | |   | || /-+--++-----\ || ||   |  |   |   |       ||   |       | || ||    |   | ||  |            ||  |
   | | | | |     | | ||         /+++------++--+-+---+-++-+-+--++-----+-++-++---+--+---+---+-\     ||   |       | || ||    |   | ||  |            ||  |
   | | | | |     | | ||     /---++++-\ /--++--+-+---+-++-+-+--++-----+-++-++---+--+---+---+-+-----++---+-------+-++-++----+---+-++--+------------++\ |
   | | | | |     | | ||     |   |||| | |  ||  | |   | || | |  ||     | || ||   |  |   |   | |     ||   |       | || ||    |/--+-++--+----------\ ||| |
   | | | | |     | | || /---+---++++-+-+--++-\| |   | || | |  ||     | ||/++---+->+---+---+-+-\   ||   |       | || ||    ||  | ||  |          | ||| |
   | | | | |     | | || |   |   |||| | |  || || |   | || | |  ||/----+-+++++---+--+---+---+-+-+---++---+-------+-++-++----++--+-++--+-----\    | ||| |
   | | | | |     | | || |   |   |||| | |  || || |   | || | |  |||    | \++++---+--+---+---+-+-+---++---+-------+-++-/|    ||  | ||  |     |    | ||| |
   \-+-+-+-+-----+-+-++-+---+---+++/ | |  \+-++-+---+-++-+-+--+++----+--++++---+--+---+---+-+-+---++---+-------+-++--+----++--+-++--+-----+----+-+++-/
   /-+-+-+-+-----+-+-++-+---+---+++--+-+---+-++-+---+-++-+-+--+++----+--++++---+--+---+---+-+-+---++---+-\     | ||  |    ||  | ||  |     |    | |||  
   | | | | |     | | || |   |   |||  | |   | || |   | || | |/-+++----+--++++---+--+---+---+-+-+---++---+-+-----+-++--+---\||  | ||  |     |    | |||  
   | | | | |     | | || |   |   ||| /+-+---+-++-+---+-++-+-++-+++----+--++++---+--+---+---+-+-+---++---+-+-----+-++--+---+++--+-++--+---\ |    | |||  
   | | | | |     | | || |   |   ||| || |  /+-++-+---+-++-+-++-+++----+--++++---+--+---+---+-+-+---++---+-+-----+-++--+---+++--+-++--+\  | |    | |||  
   | | | | |     \-+-++-+---+---+++-++-+--++-++-+---+-++-+-++-+++----+--++++---+--+---/   | | |   ||   | | /---+-++--+---+++--+-++--++--+-+---\| |||  
   | | | | |       |/++-+---+---+++-++-+--++-++-+---+-++-+-++-+++----+--++++---+--+-----\ | | |   \+---+-+-+---+-++--+---+++--+-+/  ||  | |   || |||  
   | |/+-+-+-------++++-+--\|   ||| || |  |\-++-+---+-++-+-++-+++----+--++++---+--+-----+-+-+-+----+---+-+-+---+-++--+---+/|  | |   ||  | |   || |||  
   | ||| | |    /--++++-+--++---+++-++-+--+--++-+---+-++-+-++-+++----+--++++---+--+-----+-+-+-+----+-\ | | |   | ||  |   | |  | |   ||  | |   || |||  
   | ||| | |    |  |||| |  ||   ||| || |  |/-++-+---+-++-+-++-+++----+--++++---+--+-----+-+-+-+----+-+-+-+-+---+-++--+---+-+--+-+---++--+-+---++-+++\ 
   | ||| | |    |  |||| |  ||   ||| || |  || || |  /+-++-+-++-+++----+--++++---+--+-----+-+-+-+-\  | | | | |   | ||  |   | |  | |   ||  | |   || |||| 
   | ||| | |    |  |||| |  ||   ||| || |  || || |  || || | || |||/---+--++++---+--+-----+-+-+-+-+--+-+-+-+-+---+-++-\|   | |  | |   ||  | |   || |||| 
  /+-+++-+-+----+--++++\|  ||   ||| || |  || || |  || || | || ||||   |  ||||/--+--+-----+-+-+-+-+--+-+-+-+-+---+-++-++---+-+--+-+-\ ||  | |   || |||| 
 /++-+++-+-+----+--++++++--++---+++-++-+--++-++-+--++-++-+-++-++++---+--+++++--+--+-----+-+-+-+-+--+-+-+\| |   | || ||   | |  | | | ||  | |   || |||| 
 ||| ||| | |    |  ||||||  ||   ||| || |/-++-++-+--++-++-+-++-++++---+--+++++--+--+-----+-+-+-+-+--+-+-+++-+--\| || ||   | |  | | | ||  | |   || |||| 
/+++-+++-+-+---\|  ||||||  ||   ||| || || || || |  || || |/++-++++---+--+++++--+--+-----+-+-+-+-+--+-+-+++-+--++-++-++---+-+--+-+-+-++--+-+---++\|||| 
|||| ||| | |   ||  ||||||  ||/--+++-++-++-++-++-+--++-++-++++-++++---+--+++++--+--+-----+-+-+-+-+-\| | ||| |  || || ||   | |  | | | ||  | |   ||||||| 
|||| ||| | |   ||  |||||| /+++--+++-++-++-++-++-+--++-++-++++-++++---+--+++++--+--+-----+-+-+-+-+-++-+-+++-+--++-++\||   | |  | | | ||  | |   ||||||| 
|||| ||| | |   ||  |||||| ||||  ||| || ||/++-++-+--++-++-++++-++++---+--+++++--+--+-----+-+-+-+-+-++-+-+++-+--++-+++++---+-+--+-+-+-++--+-+\  ||||||| 
|||| ||| | |   ||  |||||| ||||  ||| || ||||| || |  || || |||| ||||   |  |||||  |  |     | | | | | || | ||| |  || |||||   | |  | | | ||  | ||  ||||||| 
|||| ||| | |   ||  |||||| ||||  ||| || ||||| || |  || || |||| ||||/--+--+++++--+--+-----+-+-+-+-+-++-+-+++-+--++-+++++---+-+--+-+-+-++\ | ||  ||||||| 
|||| ||| | |   ||  |||||^ ||||  ||| || ||||| || |  || || |||| |||||  |  ||\++--+--+-----+-+-+-+-+-++-+-+++-+--++-++++/   | |  | | | ||| | ||  ||||||| 
|||| ||| | |   ||  |||||| ||||  ||| || ||||| || |  || || |||| |||||  |  || ||  |  |     | | | | | || | ||| |  || ||||    | |  | | | ||| | ||  ||||||| 
|||| ||| | |   ||  |||||| ||||  ||| || ||||| || |  || || |||| |||||  |  || ||  |  |     | |/+-+<+-++-+-+++-+--++-++++----+-+--+-+-+\||| | ||  ||||||| 
|||| ||| | |   ||  |||||| ||||  ||| ||/+++++-++-+--++-++-++++-+++++--+--++-++--+--+\    | ||| |/+-++-+-+++-+\ || ||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | /-++--++++++-++++\ ||| ||||||||/++-+--++-++-++++-+++++--+--++-++--+--++-\  | ||| ||| || | ||| || || ||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | | ||  ||\+++-+++++-++/ ||||||||||| | /++-++-++++-+++++--+--++-++--+--++-+--+-+++-+++\|| | ||| || || ||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | | ||  || ||| ||||| ||  ||||||||||| | ||| || |||| |||||  |  || ||  |  || |  | ||| |||||| | ||| || || ||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | | ||  || ||| ||||| ||  ||||||||||| | ||| || |||| |||||  |  || \+--+--++-+--+-+++-++++++-+-+++-++-+/ ||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | | ||  || ||| ||||| ||  ||||||||||| | ||| || |||| |||||  |  ||  |  |  || |  | ||| |||||| | ||| || |  ||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | | ||  || |||/+++++-++--+++++++++++-+-+++-++-++++-+++++--+--++--+--+--++-+--+-+++-++++++-+-+++-++-+-\||||    | |  | | ||||| | ||  ||||||| 
|||| ||| | | | ||  || \++++++++-+/  ||||||||||| | ||| || |||\-+++++--+--++--+--+--++-+--+-+++-++++++-+-+++-++-+-+++++----/ |  | | ||||| | ||  ||||||| 
||\+-+++-+-+-+-++--++--/||||||| |   ||||||||||| | ||| || |||  \++++--+--++--+--+--++-+--+-+++-++++++-+-+++-++-+-+++++------+--+-+-+++++-+-++--+++/||| 
|| |/+++-+-+-+\||  |\---+++++++-+---+++++++++++-+-+++-++-+++---++++--+--++--+--+--++-+--/ ||| |||||| | ||| || | |||||      |  | | ||||| | ||  ||| ||| 
|| ||||| | | ||||  |    ||||||| |   ||||||||||| | ||| || |||   ||||  |/-++--+--+--++-+\   ||| |||||| | ||| || | |||||      |  | | ||||| | ||  ||| ||| 
|| |||\+-+-+-++++--+----+++/||| \---+++++++++++-+-+++-++-+++---++++--++-++--+--+--++-++---++/ |||||| | ||| || | |||||      |  | | ||||| | ||  ||| ||| 
|| ||\-+-+-+-++++--+----+++-+++-----+++++++++++-+-+++-+/ |||   |||| /++-++--+--+--++-++---++\ |||||| | ||| || | |||||      |  | | ||||| | ||  ||| ||| 
|| ||  | | | ||||  |    ||| |||     ||||||||||| | ||| |  |\+---++++-+++-++--+--+--++-++---+++-++++++-+-+++-++-+-+++++------+--+-+-+++++-+-++--++/ ||| 
|| ||  | | | ||||  |    ||| |||     ||||||||||| | ||| |  | |   ||\+-+++-++--+--+--++-++---+++-++++++-+-+++-++-+-++++/      \--+-+-+++++-+-++--+/  ||| 
|| ||  | | | ||||  |    ||| |||     |v||||||||| | ||| |  | |   || | ||| ||  |  |  || ||   ||| |||||| | ||| || | ||||          | | ||||| | ||  |   ||| 
|| ||  | | | ||||  |    ||| |||     ||||||||||| | ||| |  \-+---++-+-+/| ||  |  |  || ||   ||| |||||| | ||| || | ||||          | | ||||| | ||  |   ||| 
|| ||  |/+-+-++++--+\   ||| |||     ||||||||||| | ||| |    |   \+-+-+-+-++--+--+--++-++---+++-++++++-+-/|| || | ||||          | |/+++++-+-++--+-\ ||| 
|| ||  ||| |/++++--++---+++-+++-----+++++++++++-+-+++-+----+----+-+-+-+-++--+--+--++-++---+++-++++++-+-\|| || | ||||          | ||||||| | ||  | | ||| 
|| ||  ||| ||||||  ||   ||| |||     ||||||||||| |/+++-+----+----+-+-+-+-++--+--+--++-++-\/+++-++++++-+-+++-++-+-++++----------+-+++++++-+-++--+-+\||| 
\+-++--+++-++++/|  ||   ||| |||     ||||||||||| ||||| |    |    | | | | ||  |  |  ||/++-+++++-++++++-+-+++-++-+-++++----------+-+++++++-+-++\ | ||||| 
 | ||  ||| |||| |  ||   ||| |||     ||||||||||| ||||| |    |    | | | | ||  |  |  ||||| ||||| |||||| | ||| || | ||||  /-------+-+++++++-+\||| | ||||| 
 |/++--+++-++++-+--++---+++-+++---\ ||||||||||| ||||| |   /+----+-+-+-+-++--+--+--+++++-+++++-++++++-+\||| || | ||||  |       | ||||||| ||||| | ||||| 
 ||v|  ||| |||| |  || /-+++-+++---+-+++++++++++\||||| |   ||    | | | | ||  |  |  ||||| |||||/++++++-+++++-++-+-++++--+-------+-+++++++-+++++-+\||||| 
 |||v  ||| |||| |  || | ||\-+++---+-+++++++++++++++++-+---++----+-+-+-+-++--+--+--+++++-++++++++++++-+++++-++-+-+++/  |       | ||||||| ||||| ||||||| 
 ||||  ||| |||| |  || | ||  |||   |/+++++++++++++++++-+---++----+-+-+-+-++--+--+--+++++-++++++++++++-+++++-++-+-+++---+-------+-+++++++\||||| ||||||| 
 |||\--+++-+++/ |  || |/++--+++---+++++++++++++++++++\|   ||    | | | | ||  |  |  ||||| |||||||\++++-+++++-+/ | |||   |       | ||||||||||||| ||||||| 
 |||   ||| |||  |  || ||||  |||   |||||\+++++++++++++++---++----+-+-+-+-++--+--+--+++++-+++++++-++++-+++++-+--+-+++---+-------+-+++++++++++++-+++++/| 
 |||   ||| |||  |  || ||||  |||/--+++++-+++++++++++++++---++----+-+-+-+-++--+--+--+++++-+++++++-++++-+++++\|  | |||   |       | ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| /++++--+++++-+++++++++++++++---++----+-+-+-+-++--+--+-\||||| ||||||| |||| |||||||  | |||   |       | ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| |||||  ||||| |||||||||||\+++---++----+-+-+-+-++--+--+-++++++-+++++++-/||| |||||||  | |||   |       | ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| |||||  ||||| |||||||||||/+++---++----+-+-+-+-++--+--+-++++++-+++++++--+++-+++++++--+-+++---+----\  | ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| |||||  ||||| |||||||||||||||   ||    | | | | ||  |  | |||||| |||||||  ||| |||||||  | |||   |    |  | ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| |||||  ||||| |||||||||||||||   ||    | | | | ||  |  | |||||| |||||||  ||| |||||||  | |||   |    |  | ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| |||||  ||||| ||||||||||||||\---++----+-+-+-+-++--+--+-++++++-+++++++--+++-+++++++--+-+++---+----+--/ ||||||||||||| ||||| | 
 |||   ||| |||  |  || |||| |\+++--+++/| ||||||||||||||    ||    | | | | ||  |  | |\++++-+++++++--+++-+++++++--+-+++---+----+----/|||||||||||| ||||| | 
 |||   ||| |||/-+--++-++++-+-+++--+++-+-++++++++++++++----++----+-+-+-+-++--+--+-+-++++-+++++++--+++-+++++++--+-+++---+-\  |     |||||||||||| ||||| | 
 |||   ||| |||| |  || |||| |/+++--+++-+-++++++++++++++----++----+-+-+-+-++--+--+-+-++++-+++++++--+++-+++++++--+-+++---+-+--+---\ |||||||||||| ||||| | 
 |||   ||| |||| |  || |||| |||||  ||| | ||||||||||||||/---++----+\| | | ||  |  | | |||| |||||||  ||| |||||||  | |||   | |  |   | |||||||||||| ||||| | 
 |||   ||| ||\+-+--++-++++-+++/|  ||| |/+++++++++++++++\  ||    ||| | | ||  |  | | |||| |||||||  ||| |||||||  | |||   | |  |   | |||||||||||| ||||| | 
 |||   ||| || | |  ||/++++-+++-+--+++-++++++++++++++++++--++----+++-+-+-++--+--+-+-++++-+++++++--+++-+++++++--+-+++-\ | |  |   | |||||||||||| ||||| | 
 |||   ||| || | |  ||||||| ||| |  ||| ||||||||||||||||||  ||    ||| | | |\--+--+-+-++++-++++++/  ||| |||||||  | ||| v | |  |   | |||||||||||| ||||| | 
 |||   ||\-++-+-+--+++++++-+++-+--+++-++++++++++++++++++--++----+++-+-+-+---+--+-+-++++-++++++---++/ |||||||  | |||/+-+-+--+---+-++++++++++++-+++++\| 
 |||   || /++-+-+--+++++++-+++\|  |\+-++++++++++++++++++--++----+++-+-+-+---+--+-+-++++-++++++---++--+++++++--+-+++++-+-+--+---+-++++++/||||| ||||||| 
 |||   || ||| | |  ||||||| |||||  | | |||||||||||\++++++--++----+++-+-+-+---+--+-+-++++-/||v||   ||  |||||||  | ||||| | |  |   | |||||| ||||| ||||||| 
 |||   || ||| | |  ||||||| |||||  | | ||||||||||| ||\+++--++----+++-+-+-/   |  | | ||||  |\+++---++--+++++++--+-+++++-+-+--+---+-+++/|| ||||| ||||||| 
 \++---++-+++-+-+--+++++++-+++++--+-+-+++++++++++-++-+++--++----+++-+-+-----+--+-+-++++--+-+++---++--+++/|||  | ||||| | |  |   | ||| || ||||| ||||||| 
  ||   || ||| | |  ||||||| |||||  | | ||||\++++++-++-+++--++----+++-+-+-----+--+-+-++++--+-+++---++--+++-+++--+-+++++-+-+--+---+-+++-/| ||||| ||||||| 
  ||   || |\+-+-+--+++++++-+++++--+-+-++++-++++++-++-+++--++----+++-+-+-----+--/ | ||||  | |||   ||  ||| |^|  | ||||| | |  |   | |||  | ||||| ||||||| 
  ||  /++-+-+-+-+\/+++++++-+++++--+-+-++++-++++++-++-+++--++----+++-+-+-----+----+-++++--+-+++---++--+++-+++--+-+++++-+-+\ |   | |||  | ||||| ||||||| 
  ||  ||| | | | |||||||||| |||||  | | |||| |||||| || |\+--++----+/| | \-----+----+-+++/  | \++---++--+++-+++--+-+++++-+-++-+---+-++/  | ||||| ||||||| 
  ||  |^| | |/+-++++++++++-+++++--+\| |||| |||||| || | |  ||    | | |       |    | |||   |  ||   ||  ||| |||  | ||||| | || |   | ||   | ||||| ||||||| 
  ||  ||| | ||| |||||||||| ||||\--+++-++++-++++++-++-+-+--++----+-+-+-------+----+-+++---+--++---++--+++-+/|  | ||||| \-++-+---+-++---+-+/||| ||||||| 
  ||  ||| | ||| |||||||||| ||||   ||| |||| |||||| || | |  ||/---+-+-+-------+----+-+++---+--++---++-\||| | |  | |||||   || |   | ||   | | ||| ||||||| 
  ||  ||| | ||| |||||||||| ||||   ||| |||| |||||| || | |  |||   \-+-+-------+----+-+++---+--++---++-++++-+-+--+-+++++---++-+---+-++---+-+-/|| ||||||| 
  ||  ||| | ||| |||||||||| |\++---+++-++++-++++++-++-+-+--+++-----+-+-------+----+-+++---+--++---++-++++-+-+--+-+++++---++-+---/ ||   | |  || ||||||| 
  ||  ||| | ||| |||\++++++-+-++---+++-++++-++++++-++-+-+--+/|     | |       |    | |||   |  ||   || |||| | |  | |||||   || |     ||   | |  || ||||||| 
  ||  |\+-+-+++-+++-++++++-+-++---+++-++++-++++++-++-+-+--+-+-----+-+-------+----+-+++---+--++---++-++++-+-+--+-+/|||   || |     ||   | |  || ||||||| 
  ||  | | | ||| ||| |||||| | ||   ||| |||| |||||\-++-+-+--+-+--<--+-+-------+----+-+++---+--++---++-++++-+-+--+-+-/||   || |     ||   | |  || ||||||| 
  ||  | | | ||| ||| |||||| | ||   ||| \+++-+++++--++-+-+--+-+-----+-+-------+----+-/||   |  ||   || |||| | |  | |  ||   || |     ||   | |  || ||||||| 
  ||  | | | |||/+++-++++++\| ||   |||  |\+-+++++--++-+-+--+-+-----+-+-------+----+--++---+--++---++-++++-+-+--/ |  ||   || |     ||   | |  || ||||||| 
  ||  \-+-+-+++++/| ||||\+++-++---+++--+-+-++/||  || | |  | |     | |       |    |  ||   |  ||   || |||| | |    |  ||   || |     ||   | |  || ||||||| 
  ||    | | ||||| | |||| ||| ||   |||  | | |\-++--++-+-+--+-+-----+-+-------+----+--+/   |  ||   || |||| | |    |  ||   || |     ||   | |  || ||||||| 
  \+----+-+-+++++-+>++++-+++-++---/||  | | \--++--++-+-+--+-+-----+-+-------+----+--+----+--++---++-++++-+-+----+--++---++-+-----++---+-+--++-++++++/ 
   |    | \-+++++-+-++++-+++-+/    ||  | |    \+--++-+-+--+-+-----+-+-------+----+--+----+--++---++-++++-+-+----+--++---++-+-----++---+-+--++-++++/|  
   |    |   |||||/+-++++-+++-+-----++--+-+-----+--++-+-+--+-+--\  | |       \>---+--+----+--++---++-++++-+-+----+--++---++-+-----+/   | |  || |||| |  
   |    | /-+++++++-++++\||| |     ||  | |     |  || | |  | |  |  | |            |  |    |  ||   || |||| | \----+--++---++-+-----+----+-+--++-/||| |  
   |    | | ||||||| |||||||| |     ||/-+-+-----+--++-+-+--+-+--+--+-+------------+--+----+--++---++-++++-+------+--++---++-+\    |    | |  ||  ||| |  
   |    | | ||||||| |||||||| |     ||| | |     |  || | |  | |  |  | |            |  \----+--++---++-++++-+------+--++---++-++----+----+-+--+/  ||| |  
   |    | | ||||||| |||||||| |  /--+++-+-+-----+--++-+-+--+-+--+--+-+------------+----\  |  ||   || |||| |      |  ||   || ||    |    | |  |   ||| |  
   |    | | ||||||| |||||||| |  |  |\+-+-+-----+--++-+-+--+-+--+--+-+------------+----+--+--++---++-++++-+------+--++---++-++----+----+-/  |   ||| |  
   \----+-+-+++++++-++++++++-+--+--+-+-+-+-----+--++-+-+--+-+--+--+-+------------+----+--+--++---++-++++-/  /---+--++--\|| ||    |    |    |   ||| |  
        | | ||||||| |||||||| |  |  | | | |     |  || | |  | |  |  | |            |    |  |  ||   || ||||    |   |/-++--+++-++----+----+--\ |   ||| |  
        | | ||||||| |||||||| |  |  | | | |   /-+--++-+-+--+-+--+--+-+------------+----+--+--++---++-++++---\|   || ||  ||| ||    |    |  | |   ||| |  
        | | ||\++++-++++++++-+--+--+-+-+-+---+-+--++-+-+--+-+--+--+-+------------+----+--+--++---++-++++---++---++-++--+/| ||    |    |  | |   ||| |  
        | | || |||| |||\++++-+--+--+-+-+-+---+-+--++-/ |  | |  |  | |            |    |  |  ||   || ||||   ||   || ||  | | ||    |    |  | |   ||| |  
        | | || |\++-+++-++++-+--+--+-+-+-+---+-+--++---+--+-+--+--+-+------------+----+--+--++---++-+/||   ||   || ||  | | ||    |    |  | |   ||| |  
        | | || | || ||| |||| |  |  | | | |   | |  ||   |  | |  |  | |            |    |  |  ||   || | ||   ||   || ||  | | ||    |    |  | |   ||| |  
        | | || | || ||| |||| |  |  | | | \---+-+--++---+--+-+--+--+-+------------+----+--+--++---++-+-++---++---++-++--+-+-++----+----+--+-/   ||| |  
        | | || | \+-+++-++++-+--+--+-+-+-----+-+--++---+--+-+--/  | |            |    |  |  ||   || | ||   ||   || ||  | | ||    |    |  |     ||| |  
        | | || |  | ||| |||| |  \--+-+-+-----+-+--++---+--+-+-----+-+------------+----/  |  ||   || | || /-++---++-++--+-+-++----+--\ |  |     ||| |  
        \-+-++-+--+-/|| |||| |     | | |     | |  ||   |  | |     | |       /----+-------+--++---++-+-++-+-++-\ || \+--+-+-++----+--+-+--+-----+++-/  
          | || |  |  || |||| |     | | \-----+-+--++---/  | |     | |       |    |       |  ||   || | || | || | ||  |  | | ||    |  | |  |     |||    
          | || |  |  \+-++++-+-----+-+-------+-+--++------+-+-----+-+-------+----+-------+--++---++-+-++-+-++-+-++--/  | | ||    |  | |  |     |||    
          | || |  |   | |||| |     | \-------+-+--++------+-+-----+-+-------+----+-------+--++---++-+-++-+-++-+-++-----+-+-+/    |  | |  |     |||    
          | || |  |   | |||| |     |         \-+--++------+-+-----+-+-------+----+-------+--++---++-+-++-+-/| | ||     | | |     |  | |  |     |||    
          | || |  |   | |\++-+-----+-----------+--++------+-+-----+-+-------+----+-------+--++---++-+-++-+--+-+-/|     | | |     \--+-+--+-----+/|    
          | \+-+--+---+-+-++-+-----+-----------+--++------+-+-----+-+-------+----+-------+--++---++-+-+/ |  \-+--+-----/ | |        | |  |     | |    
          |  | |  \---+-+-++-+-----+-----------+--++------+-+-----+-+-------+----+-------+--++---++-+-+--+----+--+-------/ |        | |  |     | |    
          \--+-+------+-/ || \-----+-----------+--++------+-+-----+-+-------+----+-------+--++---+/ | |  \----+--+---------+--------/ |  |     | |    
             | |      |   ||       |           |  ||      \-+-----+-+-------+----+-------+--++---+--+-/       |  \---------+----------+--/     | |    
             | |      |   ||       |           |  ||        |     | \-------+----+-------+--/|   |  |         |            |          |        | |    
             | |      |   ||       |           |  ||        \-----+---------+----+-------+---+---+--/         |            |          |        | |    
             \-+------+---++-------/           |  ||              |         |    |       |   |   |            |            |          |        | |    
               |      |   ||                   |  |\--------------+---------+----+-------+---+---+------------+------------/          |        | |    
               \------+---/|                   |  |               |         |    |       |   \---+------------+-----------------------+--------/ |    
                      |    |                   |  |               \---------+----+-------+-------+------------+---------<-------------/          |    
                      \----+-------------------/  \-------------------------+----+-------+-------/            |                                  |    
                           \------------------------------------------------+----/       \--------------------+----------------------------------/    
                                                                            \---------------------------------/                                       ";

        //readonly string _input = @""

        private string[] GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            return lines;
        }
       
        enum Direction
        {
            Up,
            Down, 
            Left,
            Right
        }

        enum Turn
        {
            Left, Forward, Right
        }

        class Cart
        {
            public int Pass = 0;
            public int X;
            public int Y;
            public Direction Direction;
            public Turn NextTurn = Turn.Right;

            public void DoTurn()
            {
                if (NextTurn == Turn.Right) NextTurn = Turn.Left;
                else if (NextTurn == Turn.Left) NextTurn = Turn.Forward;
                else NextTurn = Turn.Right;
            }
        }

        readonly List<Cart> _carts = new();
        string[] _lines;
        private void GetValues()
        {
            _lines = GetLines();

            for (int y = 0; y < _lines.Length; y++)
            {
                char trackReplace;

                string line = _lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    if (IsCart(c))
                    {
                        if (_lines[y][x - 1] == ' ') trackReplace = '|';
                        else trackReplace = '-';

                        _lines[y] = _lines[y].Substring(0, x) + trackReplace + _lines[y][(x + 1)..];

                        Direction direction = Direction.Up;
                        switch (c)
                        {
                            case '^': direction = Direction.Up; break;
                            case 'v': direction = Direction.Down; break;
                            case '>': direction = Direction.Right; break;
                            case '<': direction = Direction.Left; break;
                        }

                        _carts.Add(new Cart
                        {
                            X = x,
                            Y = y,
                            Direction = direction
                        });
                    }
                }
            }
        }

        static bool IsCart(char track) => new char[] { 'v', '^', '<', '>' }.Contains(track);

        bool MoveNext (Cart cart)
        {
            int nextX = cart.X, nextY = cart.Y;
            if (cart.Direction == Direction.Right) nextX++;
            else if (cart.Direction == Direction.Left) nextX--;
            else if (cart.Direction == Direction.Down) nextY++;
            else if (cart.Direction == Direction.Up) nextY--;

            char nextTrack = _lines[nextY][nextX];

            //Do the turnings
            cart.X = nextX;
            cart.Y = nextY;

            if(nextTrack == '/')
            {
                if (cart.Direction == Direction.Right) cart.Direction = Direction.Up;
                else if (cart.Direction == Direction.Down) cart.Direction = Direction.Left;
                else if (cart.Direction == Direction.Left) cart.Direction = Direction.Down;
                else if (cart.Direction == Direction.Up) cart.Direction = Direction.Right;
            }
            else if(nextTrack == '\\')
            {
                if (cart.Direction == Direction.Right) cart.Direction = Direction.Down;
                else if (cart.Direction == Direction.Down) cart.Direction = Direction.Right;
                else if (cart.Direction == Direction.Left) cart.Direction = Direction.Up;
                else if (cart.Direction == Direction.Up) cart.Direction = Direction.Left;
            }
            else if(nextTrack == '+')
            {
                cart.DoTurn();
                if(cart.NextTurn == Turn.Left)
                {
                    if (cart.Direction == Direction.Left) cart.Direction = Direction.Down;
                    else if (cart.Direction == Direction.Down) cart.Direction = Direction.Right;
                    else if (cart.Direction == Direction.Right) cart.Direction = Direction.Up;
                    else if (cart.Direction == Direction.Up) cart.Direction = Direction.Left;
                }
                else if(cart.NextTurn == Turn.Right)
                {
                    if (cart.Direction == Direction.Left) cart.Direction = Direction.Up;
                    else if (cart.Direction == Direction.Down) cart.Direction = Direction.Left;
                    else if (cart.Direction == Direction.Right) cart.Direction = Direction.Down;
                    else if (cart.Direction == Direction.Up) cart.Direction = Direction.Right;
                }
            }

            cart.Pass++;

            if(_carts.Count(s => s.X == nextX && s.Y == nextY) > 1)
            {
                _carts.RemoveAll(s => s.X == nextX && s.Y == nextY);
                return true;
            }
            return false;
        }

        public string Task1()
        {
            GetValues();

            bool hasCollision = false;
            int pass = 0;
            while (!hasCollision)
            {
                for (int y = 0; y < _lines.Length; y++)
                {
                    string line = _lines[y];
                    for (int x = 0; x < line.Length; x++)
                    {
                        Cart cart = _carts.FirstOrDefault(s => s.Pass == pass && s.X == x && s.Y == y);

                        if (cart != null)
                        {
                            hasCollision = MoveNext(cart);
                            if (hasCollision && _carts.Count == 1)
                            {
                                //
                            }
                        }
                    }
                }
                pass++;
            }

            return "";
        }

        public string Task2()
        {
            GetValues();
            return "";
        }
    }
}