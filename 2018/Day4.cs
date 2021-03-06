using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC._2018
{

    class Day4
    {

        readonly string _input = @"[1518-09-16 23:57] Guard #1889 begins shift
        [1518-04-16 00:03] Guard #2897 begins shift
        [1518-04-29 23:57] Guard #1663 begins shift
        [1518-05-27 00:47] wakes up
        [1518-04-27 23:50] Guard #661 begins shift
        [1518-08-29 00:58] wakes up
        [1518-09-26 00:48] falls asleep
        [1518-07-16 00:43] wakes up
        [1518-08-17 00:26] falls asleep
        [1518-08-17 00:53] wakes up
        [1518-09-02 00:55] falls asleep
        [1518-10-25 00:02] Guard #661 begins shift
        [1518-08-07 00:00] Guard #61 begins shift
        [1518-11-06 00:52] wakes up
        [1518-08-24 00:33] falls asleep
        [1518-09-12 00:32] wakes up
        [1518-08-29 00:46] wakes up
        [1518-09-01 00:45] wakes up
        [1518-09-16 00:01] Guard #1291 begins shift
        [1518-06-13 23:46] Guard #3307 begins shift
        [1518-05-01 00:49] wakes up
        [1518-09-29 00:05] falls asleep
        [1518-11-04 23:54] Guard #1433 begins shift
        [1518-09-19 00:03] falls asleep
        [1518-10-31 23:54] Guard #409 begins shift
        [1518-08-02 00:53] wakes up
        [1518-05-23 00:08] falls asleep
        [1518-10-04 00:43] falls asleep
        [1518-08-26 00:43] falls asleep
        [1518-04-14 00:31] wakes up
        [1518-04-11 23:58] Guard #1471 begins shift
        [1518-05-11 00:04] falls asleep
        [1518-06-14 00:04] falls asleep
        [1518-07-24 00:54] falls asleep
        [1518-08-23 00:04] falls asleep
        [1518-09-02 00:01] Guard #1433 begins shift
        [1518-04-10 00:49] wakes up
        [1518-08-09 00:20] wakes up
        [1518-05-28 00:41] wakes up
        [1518-05-24 00:02] Guard #2633 begins shift
        [1518-09-14 00:00] Guard #3121 begins shift
        [1518-08-11 00:17] falls asleep
        [1518-05-12 00:47] falls asleep
        [1518-06-27 00:47] wakes up
        [1518-11-13 00:20] falls asleep
        [1518-06-24 23:59] Guard #3121 begins shift
        [1518-09-14 00:56] wakes up
        [1518-11-19 00:58] wakes up
        [1518-11-21 00:38] falls asleep
        [1518-06-15 00:02] Guard #409 begins shift
        [1518-11-17 00:31] falls asleep
        [1518-04-06 00:40] wakes up
        [1518-09-06 00:42] falls asleep
        [1518-11-11 00:37] falls asleep
        [1518-06-19 23:49] Guard #2819 begins shift
        [1518-07-12 23:53] Guard #3037 begins shift
        [1518-10-11 00:50] wakes up
        [1518-11-13 00:40] wakes up
        [1518-10-15 00:52] wakes up
        [1518-06-14 00:07] wakes up
        [1518-10-25 00:54] falls asleep
        [1518-05-25 00:59] wakes up
        [1518-05-17 00:33] falls asleep
        [1518-08-03 23:54] Guard #2459 begins shift
        [1518-10-03 00:17] falls asleep
        [1518-09-22 00:34] falls asleep
        [1518-05-23 00:29] falls asleep
        [1518-05-08 00:14] falls asleep
        [1518-07-15 00:19] falls asleep
        [1518-06-26 00:48] wakes up
        [1518-09-12 00:30] falls asleep
        [1518-07-11 00:38] wakes up
        [1518-10-11 00:43] falls asleep
        [1518-09-30 00:07] falls asleep
        [1518-10-15 00:20] falls asleep
        [1518-10-27 00:50] falls asleep
        [1518-08-11 00:02] Guard #1931 begins shift
        [1518-06-25 00:58] wakes up
        [1518-11-13 00:02] Guard #2447 begins shift
        [1518-10-27 00:41] wakes up
        [1518-04-24 00:05] falls asleep
        [1518-06-30 00:00] falls asleep
        [1518-04-23 00:58] wakes up
        [1518-11-19 00:42] falls asleep
        [1518-07-18 00:52] wakes up
        [1518-08-22 23:46] Guard #61 begins shift
        [1518-07-05 23:50] Guard #1889 begins shift
        [1518-05-20 00:04] falls asleep
        [1518-07-12 00:30] wakes up
        [1518-10-21 00:10] falls asleep
        [1518-10-12 00:02] Guard #947 begins shift
        [1518-06-28 00:35] falls asleep
        [1518-11-09 00:33] wakes up
        [1518-11-17 00:00] Guard #409 begins shift
        [1518-11-07 00:12] falls asleep
        [1518-06-04 00:59] wakes up
        [1518-06-30 00:33] falls asleep
        [1518-09-02 00:22] falls asleep
        [1518-11-06 23:59] Guard #2459 begins shift
        [1518-09-27 23:52] Guard #947 begins shift
        [1518-10-27 00:35] falls asleep
        [1518-07-22 00:00] Guard #1889 begins shift
        [1518-06-21 00:53] wakes up
        [1518-05-06 00:50] wakes up
        [1518-06-11 23:58] Guard #1931 begins shift
        [1518-10-08 00:00] Guard #1433 begins shift
        [1518-09-09 00:25] wakes up
        [1518-04-23 23:47] Guard #1291 begins shift
        [1518-04-09 23:59] Guard #61 begins shift
        [1518-10-02 00:38] wakes up
        [1518-06-30 00:14] wakes up
        [1518-06-14 00:44] falls asleep
        [1518-07-19 00:04] Guard #1283 begins shift
        [1518-09-08 00:02] Guard #467 begins shift
        [1518-06-19 00:56] falls asleep
        [1518-08-08 00:10] falls asleep
        [1518-11-19 00:36] wakes up
        [1518-11-02 00:42] falls asleep
        [1518-05-24 00:40] wakes up
        [1518-06-08 00:43] wakes up
        [1518-04-23 00:57] falls asleep
        [1518-08-26 00:33] falls asleep
        [1518-10-06 00:36] falls asleep
        [1518-05-02 00:59] wakes up
        [1518-07-29 00:49] wakes up
        [1518-08-24 00:39] wakes up
        [1518-05-07 00:02] Guard #947 begins shift
        [1518-11-11 00:12] falls asleep
        [1518-11-17 00:32] wakes up
        [1518-10-09 00:19] falls asleep
        [1518-08-13 00:48] wakes up
        [1518-09-02 23:56] Guard #947 begins shift
        [1518-09-20 00:02] Guard #3121 begins shift
        [1518-10-12 00:47] falls asleep
        [1518-08-01 00:10] falls asleep
        [1518-10-01 00:47] wakes up
        [1518-05-11 00:05] wakes up
        [1518-09-13 00:16] wakes up
        [1518-08-24 00:59] wakes up
        [1518-08-26 00:47] wakes up
        [1518-08-29 00:30] falls asleep
        [1518-08-15 00:04] Guard #2447 begins shift
        [1518-05-04 00:56] wakes up
        [1518-09-07 00:55] wakes up
        [1518-07-11 23:53] Guard #409 begins shift
        [1518-11-20 00:31] falls asleep
        [1518-05-07 00:18] falls asleep
        [1518-05-04 00:30] wakes up
        [1518-09-24 00:42] wakes up
        [1518-05-18 00:21] falls asleep
        [1518-07-18 00:02] Guard #1663 begins shift
        [1518-04-16 00:35] wakes up
        [1518-10-19 00:46] falls asleep
        [1518-06-21 00:05] falls asleep
        [1518-08-30 00:34] falls asleep
        [1518-09-23 00:45] falls asleep
        [1518-06-04 00:53] falls asleep
        [1518-11-07 00:34] wakes up
        [1518-09-07 00:45] wakes up
        [1518-07-01 00:48] falls asleep
        [1518-10-10 00:47] wakes up
        [1518-05-02 00:46] wakes up
        [1518-06-14 00:52] wakes up
        [1518-07-17 00:31] falls asleep
        [1518-05-19 23:53] Guard #3307 begins shift
        [1518-09-13 00:03] falls asleep
        [1518-07-02 00:54] wakes up
        [1518-05-22 00:29] falls asleep
        [1518-10-19 23:56] Guard #2447 begins shift
        [1518-09-26 00:56] wakes up
        [1518-04-10 00:11] falls asleep
        [1518-09-28 23:52] Guard #2819 begins shift
        [1518-08-08 23:48] Guard #1663 begins shift
        [1518-05-04 00:37] falls asleep
        [1518-10-21 23:58] Guard #3491 begins shift
        [1518-09-15 00:42] falls asleep
        [1518-06-24 00:40] falls asleep
        [1518-09-22 00:53] wakes up
        [1518-04-08 00:01] falls asleep
        [1518-06-01 00:36] wakes up
        [1518-05-15 00:04] Guard #2633 begins shift
        [1518-07-03 00:11] falls asleep
        [1518-07-20 00:30] falls asleep
        [1518-09-09 00:53] wakes up
        [1518-04-12 00:57] falls asleep
        [1518-10-19 00:00] Guard #2633 begins shift
        [1518-11-05 00:53] wakes up
        [1518-10-26 00:19] falls asleep
        [1518-07-07 00:04] falls asleep
        [1518-05-25 00:39] falls asleep
        [1518-04-11 00:59] wakes up
        [1518-07-27 00:04] Guard #2459 begins shift
        [1518-08-17 00:40] wakes up
        [1518-09-04 00:32] falls asleep
        [1518-04-25 00:00] Guard #1889 begins shift
        [1518-11-02 00:51] wakes up
        [1518-05-22 00:30] wakes up
        [1518-04-19 00:56] wakes up
        [1518-09-16 00:39] falls asleep
        [1518-09-03 00:44] falls asleep
        [1518-07-08 23:56] Guard #661 begins shift
        [1518-10-02 00:58] wakes up
        [1518-04-12 23:59] Guard #2633 begins shift
        [1518-09-26 23:56] Guard #2633 begins shift
        [1518-08-26 00:40] wakes up
        [1518-08-21 00:01] falls asleep
        [1518-10-27 00:56] wakes up
        [1518-06-22 00:01] Guard #467 begins shift
        [1518-06-17 00:59] wakes up
        [1518-09-17 00:36] falls asleep
        [1518-04-24 00:21] wakes up
        [1518-09-04 00:45] wakes up
        [1518-06-07 00:48] wakes up
        [1518-10-16 00:57] wakes up
        [1518-06-09 00:11] falls asleep
        [1518-05-06 00:03] Guard #1283 begins shift
        [1518-09-11 23:58] Guard #409 begins shift
        [1518-09-10 00:04] falls asleep
        [1518-10-02 00:50] falls asleep
        [1518-05-23 00:54] wakes up
        [1518-08-21 00:54] wakes up
        [1518-10-12 23:56] Guard #61 begins shift
        [1518-07-13 00:42] wakes up
        [1518-06-08 23:59] Guard #2633 begins shift
        [1518-08-03 00:25] wakes up
        [1518-04-26 00:32] falls asleep
        [1518-04-09 00:39] wakes up
        [1518-07-11 00:20] falls asleep
        [1518-07-01 00:21] falls asleep
        [1518-07-17 00:04] Guard #3121 begins shift
        [1518-05-10 23:51] Guard #2459 begins shift
        [1518-11-17 00:55] wakes up
        [1518-05-23 00:25] wakes up
        [1518-09-12 00:23] wakes up
        [1518-06-26 00:00] Guard #2897 begins shift
        [1518-08-26 00:03] Guard #1433 begins shift
        [1518-10-07 00:32] wakes up
        [1518-11-22 00:37] falls asleep
        [1518-06-08 00:15] falls asleep
        [1518-04-26 23:58] Guard #1291 begins shift
        [1518-05-24 00:50] wakes up
        [1518-10-19 00:56] falls asleep
        [1518-08-19 00:26] falls asleep
        [1518-04-30 23:56] Guard #1471 begins shift
        [1518-06-16 00:07] falls asleep
        [1518-06-04 00:00] Guard #3307 begins shift
        [1518-04-21 00:00] Guard #1283 begins shift
        [1518-10-29 00:14] falls asleep
        [1518-07-05 00:06] falls asleep
        [1518-07-09 00:28] wakes up
        [1518-06-20 23:50] Guard #3307 begins shift
        [1518-04-19 00:04] Guard #2897 begins shift
        [1518-07-08 00:26] wakes up
        [1518-07-23 00:24] falls asleep
        [1518-05-16 00:55] wakes up
        [1518-07-19 00:51] wakes up
        [1518-10-13 23:49] Guard #61 begins shift
        [1518-06-28 00:29] falls asleep
        [1518-11-12 00:17] wakes up
        [1518-07-03 00:43] wakes up
        [1518-05-17 00:05] falls asleep
        [1518-09-10 00:48] falls asleep
        [1518-06-11 00:18] falls asleep
        [1518-04-09 00:01] falls asleep
        [1518-09-12 00:13] falls asleep
        [1518-06-11 00:01] Guard #1471 begins shift
        [1518-06-17 00:00] Guard #3307 begins shift
        [1518-06-19 00:40] falls asleep
        [1518-10-01 00:43] falls asleep
        [1518-04-30 00:19] falls asleep
        [1518-04-22 00:53] wakes up
        [1518-11-15 00:03] Guard #419 begins shift
        [1518-08-07 00:54] falls asleep
        [1518-06-13 00:53] falls asleep
        [1518-11-08 00:34] falls asleep
        [1518-06-13 00:58] wakes up
        [1518-10-26 00:47] wakes up
        [1518-04-20 00:33] wakes up
        [1518-07-24 00:01] Guard #1291 begins shift
        [1518-04-12 00:50] wakes up
        [1518-11-02 00:23] falls asleep
        [1518-09-25 00:50] falls asleep
        [1518-09-24 00:46] falls asleep
        [1518-05-04 23:58] Guard #661 begins shift
        [1518-05-27 00:07] falls asleep
        [1518-09-17 00:23] wakes up
        [1518-10-11 00:55] wakes up
        [1518-09-15 00:27] falls asleep
        [1518-10-30 23:52] Guard #1291 begins shift
        [1518-10-23 00:39] wakes up
        [1518-09-20 00:48] wakes up
        [1518-04-07 00:04] falls asleep
        [1518-05-03 00:39] falls asleep
        [1518-07-26 00:57] wakes up
        [1518-06-23 00:00] Guard #947 begins shift
        [1518-06-18 00:33] falls asleep
        [1518-08-29 23:58] Guard #2633 begins shift
        [1518-06-08 00:33] falls asleep
        [1518-05-25 00:57] falls asleep
        [1518-05-09 00:37] wakes up
        [1518-11-21 00:40] wakes up
        [1518-09-30 00:56] falls asleep
        [1518-08-01 00:00] Guard #61 begins shift
        [1518-06-05 00:54] falls asleep
        [1518-09-28 00:03] falls asleep
        [1518-05-09 00:09] falls asleep
        [1518-05-24 00:21] falls asleep
        [1518-06-07 00:04] falls asleep
        [1518-07-25 00:07] wakes up
        [1518-06-26 00:25] falls asleep
        [1518-11-17 00:47] falls asleep
        [1518-09-25 00:40] wakes up
        [1518-05-21 00:35] falls asleep
        [1518-07-28 00:34] falls asleep
        [1518-09-04 00:01] Guard #2633 begins shift
        [1518-06-12 23:56] Guard #2897 begins shift
        [1518-11-11 00:45] wakes up
        [1518-09-02 00:56] wakes up
        [1518-06-14 00:18] wakes up
        [1518-11-13 23:57] Guard #2459 begins shift
        [1518-06-21 00:47] falls asleep
        [1518-05-25 23:48] Guard #2633 begins shift
        [1518-07-01 00:56] wakes up
        [1518-04-06 00:18] falls asleep
        [1518-07-08 00:12] falls asleep
        [1518-08-04 23:56] Guard #947 begins shift
        [1518-07-06 23:49] Guard #1663 begins shift
        [1518-09-08 23:51] Guard #3307 begins shift
        [1518-07-13 00:01] falls asleep
        [1518-07-24 00:30] wakes up
        [1518-05-10 00:38] wakes up
        [1518-04-06 23:54] Guard #3121 begins shift
        [1518-10-05 00:01] Guard #3121 begins shift
        [1518-06-01 00:04] Guard #3307 begins shift
        [1518-10-02 00:12] falls asleep
        [1518-09-01 00:40] falls asleep
        [1518-05-01 00:31] falls asleep
        [1518-10-10 00:55] falls asleep
        [1518-09-11 00:02] Guard #2819 begins shift
        [1518-04-28 00:16] wakes up
        [1518-11-20 00:48] wakes up
        [1518-05-14 00:45] falls asleep
        [1518-04-11 00:15] falls asleep
        [1518-10-06 00:49] wakes up
        [1518-04-15 00:46] wakes up
        [1518-07-08 00:03] Guard #2633 begins shift
        [1518-05-03 00:56] wakes up
        [1518-08-28 23:57] Guard #1433 begins shift
        [1518-10-23 00:42] falls asleep
        [1518-05-30 23:48] Guard #409 begins shift
        [1518-06-04 00:31] falls asleep
        [1518-11-08 00:04] Guard #61 begins shift
        [1518-04-26 00:42] wakes up
        [1518-06-15 00:47] falls asleep
        [1518-09-01 00:24] falls asleep
        [1518-10-06 00:26] wakes up
        [1518-05-23 00:58] wakes up
        [1518-08-12 00:07] falls asleep
        [1518-04-29 00:19] falls asleep
        [1518-09-26 00:04] Guard #409 begins shift
        [1518-09-05 00:22] falls asleep
        [1518-10-02 00:02] Guard #3037 begins shift
        [1518-07-30 00:38] falls asleep
        [1518-05-19 00:19] falls asleep
        [1518-06-02 00:49] wakes up
        [1518-07-01 00:42] wakes up
        [1518-07-05 00:50] falls asleep
        [1518-06-12 00:23] falls asleep
        [1518-05-20 23:57] Guard #2897 begins shift
        [1518-06-17 23:59] Guard #1931 begins shift
        [1518-05-27 00:20] wakes up
        [1518-06-28 00:00] Guard #1889 begins shift
        [1518-09-21 00:02] falls asleep
        [1518-10-06 23:57] Guard #3037 begins shift
        [1518-08-25 00:41] wakes up
        [1518-04-19 00:55] falls asleep
        [1518-08-16 00:21] falls asleep
        [1518-08-09 00:01] falls asleep
        [1518-10-21 00:00] Guard #3307 begins shift
        [1518-08-24 00:56] falls asleep
        [1518-05-27 00:03] Guard #61 begins shift
        [1518-05-21 00:13] falls asleep
        [1518-09-30 00:02] Guard #1291 begins shift
        [1518-11-10 00:28] wakes up
        [1518-06-02 23:57] Guard #2819 begins shift
        [1518-05-29 00:57] wakes up
        [1518-10-19 00:39] wakes up
        [1518-04-21 00:43] wakes up
        [1518-08-31 00:02] Guard #3037 begins shift
        [1518-05-05 00:58] wakes up
        [1518-04-25 00:40] wakes up
        [1518-11-20 00:59] wakes up
        [1518-09-02 00:52] wakes up
        [1518-05-17 00:47] wakes up
        [1518-09-22 23:56] Guard #1283 begins shift
        [1518-07-01 23:53] Guard #467 begins shift
        [1518-05-02 00:41] falls asleep
        [1518-08-01 23:59] Guard #1433 begins shift
        [1518-10-27 23:50] Guard #3121 begins shift
        [1518-07-29 00:00] Guard #2447 begins shift
        [1518-05-21 00:52] wakes up
        [1518-04-15 00:00] Guard #467 begins shift
        [1518-09-17 00:41] wakes up
        [1518-10-13 00:14] falls asleep
        [1518-09-08 00:53] falls asleep
        [1518-04-17 00:28] falls asleep
        [1518-11-06 00:02] Guard #3307 begins shift
        [1518-09-07 00:49] falls asleep
        [1518-05-15 00:24] falls asleep
        [1518-05-13 00:23] falls asleep
        [1518-10-04 00:24] wakes up
        [1518-06-30 23:58] Guard #1291 begins shift
        [1518-07-10 23:51] Guard #1889 begins shift
        [1518-04-13 00:23] falls asleep
        [1518-08-25 00:01] Guard #467 begins shift
        [1518-04-16 00:59] wakes up
        [1518-10-24 00:04] Guard #167 begins shift
        [1518-06-22 00:09] falls asleep
        [1518-11-12 00:51] wakes up
        [1518-08-01 00:42] wakes up
        [1518-06-04 00:32] wakes up
        [1518-10-06 00:00] Guard #3037 begins shift
        [1518-11-06 00:22] falls asleep
        [1518-08-17 00:44] wakes up
        [1518-10-13 00:44] wakes up
        [1518-05-31 00:56] wakes up
        [1518-10-06 00:13] falls asleep
        [1518-08-16 00:58] wakes up
        [1518-05-12 00:49] wakes up
        [1518-06-18 00:52] falls asleep
        [1518-11-02 00:35] wakes up
        [1518-05-28 00:38] falls asleep
        [1518-06-29 23:54] Guard #1283 begins shift
        [1518-05-28 00:45] falls asleep
        [1518-04-22 00:27] wakes up
        [1518-10-30 00:44] wakes up
        [1518-06-12 00:58] wakes up
        [1518-07-05 00:28] wakes up
        [1518-09-01 00:03] Guard #1471 begins shift
        [1518-04-18 00:34] wakes up
        [1518-09-08 00:45] wakes up
        [1518-08-25 00:39] falls asleep
        [1518-04-12 00:24] falls asleep
        [1518-07-25 23:50] Guard #1291 begins shift
        [1518-07-24 23:57] Guard #3121 begins shift
        [1518-06-05 00:21] wakes up
        [1518-08-21 00:30] falls asleep
        [1518-06-04 00:54] wakes up
        [1518-11-10 00:02] Guard #2897 begins shift
        [1518-04-30 00:55] wakes up
        [1518-09-14 00:31] wakes up
        [1518-05-26 00:00] falls asleep
        [1518-09-25 00:57] wakes up
        [1518-05-14 00:53] wakes up
        [1518-07-21 00:29] falls asleep
        [1518-07-16 00:38] falls asleep
        [1518-07-04 00:37] falls asleep
        [1518-04-21 00:28] wakes up
        [1518-04-08 00:13] wakes up
        [1518-04-22 00:01] Guard #947 begins shift
        [1518-09-24 23:50] Guard #1931 begins shift
        [1518-09-22 00:09] falls asleep
        [1518-10-17 00:52] wakes up
        [1518-10-26 23:58] Guard #2897 begins shift
        [1518-06-03 00:55] wakes up
        [1518-04-25 23:46] Guard #409 begins shift
        [1518-04-20 00:01] Guard #2459 begins shift
        [1518-10-01 00:17] falls asleep
        [1518-07-21 00:12] falls asleep
        [1518-06-19 00:03] Guard #3121 begins shift
        [1518-09-15 00:01] Guard #2447 begins shift
        [1518-09-29 00:30] wakes up
        [1518-07-15 00:01] Guard #947 begins shift
        [1518-08-03 00:04] Guard #1433 begins shift
        [1518-06-05 00:17] falls asleep
        [1518-08-24 00:04] Guard #1291 begins shift
        [1518-05-18 00:03] Guard #409 begins shift
        [1518-08-05 00:45] wakes up
        [1518-08-08 00:39] wakes up
        [1518-09-16 00:54] wakes up
        [1518-08-31 00:39] wakes up
        [1518-08-13 00:00] Guard #947 begins shift
        [1518-07-08 00:57] falls asleep
        [1518-05-29 00:33] wakes up
        [1518-08-06 00:42] falls asleep
        [1518-08-31 00:24] falls asleep
        [1518-07-06 00:04] falls asleep
        [1518-07-29 00:26] falls asleep
        [1518-04-05 00:02] Guard #2459 begins shift
        [1518-05-18 23:56] Guard #2633 begins shift
        [1518-04-05 00:26] falls asleep
        [1518-09-22 00:02] Guard #1663 begins shift
        [1518-09-13 00:48] wakes up
        [1518-06-05 00:57] wakes up
        [1518-04-29 00:49] wakes up
        [1518-11-19 00:53] falls asleep
        [1518-10-23 00:57] wakes up
        [1518-08-07 00:29] falls asleep
        [1518-10-11 00:24] wakes up
        [1518-08-28 00:27] wakes up
        [1518-05-07 00:41] falls asleep
        [1518-05-03 23:59] Guard #2633 begins shift
        [1518-08-15 23:59] Guard #2459 begins shift
        [1518-09-06 00:49] wakes up
        [1518-10-23 00:34] falls asleep
        [1518-05-12 00:00] Guard #2819 begins shift
        [1518-08-04 00:52] wakes up
        [1518-11-18 23:56] Guard #3121 begins shift
        [1518-08-14 00:43] wakes up
        [1518-07-30 00:01] Guard #3307 begins shift
        [1518-10-31 00:11] wakes up
        [1518-10-04 00:03] Guard #947 begins shift
        [1518-09-27 00:56] wakes up
        [1518-07-05 00:20] wakes up
        [1518-05-16 00:00] Guard #1931 begins shift
        [1518-05-28 23:58] Guard #947 begins shift
        [1518-08-04 00:02] falls asleep
        [1518-05-08 23:57] Guard #2633 begins shift
        [1518-08-02 00:40] falls asleep
        [1518-08-07 00:59] wakes up
        [1518-10-09 00:56] wakes up
        [1518-05-24 00:31] wakes up
        [1518-09-06 00:36] wakes up
        [1518-04-10 23:58] Guard #1931 begins shift
        [1518-08-07 00:12] falls asleep
        [1518-08-20 00:57] wakes up
        [1518-11-11 23:58] Guard #2819 begins shift
        [1518-08-07 00:17] wakes up
        [1518-08-11 23:58] Guard #661 begins shift
        [1518-11-03 00:53] falls asleep
        [1518-08-18 23:57] Guard #467 begins shift
        [1518-04-13 00:35] wakes up
        [1518-09-20 23:53] Guard #2447 begins shift
        [1518-07-27 00:10] falls asleep
        [1518-08-19 00:38] wakes up
        [1518-08-27 00:01] Guard #947 begins shift
        [1518-10-16 23:56] Guard #3307 begins shift
        [1518-06-23 00:50] wakes up
        [1518-10-19 00:47] wakes up
        [1518-09-21 00:52] wakes up
        [1518-06-06 00:46] wakes up
        [1518-06-20 00:44] wakes up
        [1518-08-06 00:02] Guard #947 begins shift
        [1518-08-28 00:21] falls asleep
        [1518-08-27 00:25] wakes up
        [1518-10-18 00:54] wakes up
        [1518-06-22 00:45] wakes up
        [1518-06-13 00:47] wakes up
        [1518-05-09 00:47] wakes up
        [1518-06-09 23:57] Guard #2633 begins shift
        [1518-11-21 23:58] Guard #467 begins shift
        [1518-05-08 00:02] Guard #2447 begins shift
        [1518-05-22 00:01] Guard #409 begins shift
        [1518-09-09 23:48] Guard #1931 begins shift
        [1518-05-28 00:01] Guard #1291 begins shift
        [1518-08-27 00:15] falls asleep
        [1518-07-07 00:26] falls asleep
        [1518-11-10 00:39] falls asleep
        [1518-10-19 00:08] falls asleep
        [1518-06-20 00:01] falls asleep
        [1518-09-24 00:31] falls asleep
        [1518-11-10 00:47] wakes up
        [1518-10-23 00:11] falls asleep
        [1518-07-04 00:04] Guard #1889 begins shift
        [1518-09-05 00:41] wakes up
        [1518-06-01 00:11] falls asleep
        [1518-05-20 00:44] wakes up
        [1518-10-31 00:00] falls asleep
        [1518-09-05 00:04] Guard #409 begins shift
        [1518-05-22 00:19] falls asleep
        [1518-07-12 00:00] falls asleep
        [1518-10-25 00:55] wakes up
        [1518-09-08 00:57] wakes up
        [1518-08-07 00:41] wakes up
        [1518-07-22 00:11] falls asleep
        [1518-06-28 23:58] Guard #419 begins shift
        [1518-09-07 00:03] Guard #409 begins shift
        [1518-04-29 00:01] Guard #661 begins shift
        [1518-10-01 00:33] wakes up
        [1518-10-05 00:35] wakes up
        [1518-06-06 00:04] Guard #1663 begins shift
        [1518-10-17 00:35] falls asleep
        [1518-04-27 00:15] falls asleep
        [1518-06-16 00:54] wakes up
        [1518-08-17 00:04] Guard #1283 begins shift
        [1518-07-23 00:57] wakes up
        [1518-05-03 00:26] falls asleep
        [1518-06-23 00:28] falls asleep
        [1518-08-16 00:48] falls asleep
        [1518-07-27 00:56] wakes up
        [1518-05-25 00:28] wakes up
        [1518-09-05 23:59] Guard #1283 begins shift
        [1518-05-24 23:58] Guard #661 begins shift
        [1518-10-09 00:38] wakes up
        [1518-11-12 00:11] falls asleep
        [1518-11-20 00:54] falls asleep
        [1518-11-16 00:00] Guard #1663 begins shift
        [1518-05-28 00:34] wakes up
        [1518-10-28 00:04] falls asleep
        [1518-07-14 00:59] wakes up
        [1518-05-16 00:51] falls asleep
        [1518-10-20 00:42] wakes up
        [1518-04-07 00:27] falls asleep
        [1518-07-08 00:38] falls asleep
        [1518-07-07 00:10] wakes up
        [1518-10-15 00:00] Guard #947 begins shift
        [1518-07-21 00:49] falls asleep
        [1518-08-03 00:06] falls asleep
        [1518-09-18 00:31] falls asleep
        [1518-10-05 00:17] falls asleep
        [1518-08-28 00:45] wakes up
        [1518-11-14 00:58] wakes up
        [1518-11-05 00:03] falls asleep
        [1518-05-22 00:22] wakes up
        [1518-06-10 00:29] falls asleep
        [1518-08-16 00:38] wakes up
        [1518-05-02 00:49] falls asleep
        [1518-08-28 00:37] falls asleep
        [1518-05-31 00:05] falls asleep
        [1518-08-06 00:49] wakes up
        [1518-04-05 23:56] Guard #2633 begins shift
        [1518-08-20 00:03] falls asleep
        [1518-05-29 00:47] falls asleep
        [1518-05-09 00:57] wakes up
        [1518-05-17 00:58] wakes up
        [1518-09-18 00:04] Guard #2459 begins shift
        [1518-08-14 00:29] falls asleep
        [1518-05-23 00:48] falls asleep
        [1518-07-24 00:08] falls asleep
        [1518-04-20 00:30] falls asleep
        [1518-07-30 00:54] wakes up
        [1518-10-28 00:53] wakes up
        [1518-07-02 00:00] falls asleep
        [1518-08-21 00:13] wakes up
        [1518-05-26 00:56] wakes up
        [1518-11-16 00:19] falls asleep
        [1518-08-15 00:41] falls asleep
        [1518-11-01 00:01] falls asleep
        [1518-08-07 00:51] wakes up
        [1518-10-08 00:48] falls asleep
        [1518-09-09 00:03] falls asleep
        [1518-05-25 00:41] wakes up
        [1518-07-19 00:40] wakes up
        [1518-05-17 00:57] falls asleep
        [1518-05-23 00:44] wakes up
        [1518-11-01 00:48] wakes up
        [1518-05-16 23:54] Guard #1471 begins shift
        [1518-06-02 00:03] Guard #1931 begins shift
        [1518-05-10 00:35] falls asleep
        [1518-05-13 00:04] Guard #2633 begins shift
        [1518-04-25 00:38] falls asleep
        [1518-04-22 00:44] falls asleep
        [1518-05-24 00:36] falls asleep
        [1518-07-25 00:06] falls asleep
        [1518-05-31 00:50] falls asleep
        [1518-10-21 00:44] wakes up
        [1518-05-23 00:57] falls asleep
        [1518-10-01 00:03] Guard #61 begins shift
        [1518-09-22 00:10] wakes up
        [1518-10-29 00:33] wakes up
        [1518-06-19 00:58] wakes up
        [1518-06-30 00:57] wakes up
        [1518-05-21 00:48] falls asleep
        [1518-06-06 23:47] Guard #3307 begins shift
        [1518-08-09 00:39] falls asleep
        [1518-07-14 00:11] falls asleep
        [1518-07-28 00:57] wakes up
        [1518-07-05 00:53] wakes up
        [1518-09-13 00:25] falls asleep
        [1518-11-11 00:24] wakes up
        [1518-09-20 00:08] falls asleep
        [1518-09-15 00:35] wakes up
        [1518-11-03 00:57] wakes up
        [1518-06-08 00:48] falls asleep
        [1518-11-19 00:49] wakes up
        [1518-10-08 00:50] wakes up
        [1518-07-15 00:52] wakes up
        [1518-07-24 00:55] wakes up
        [1518-08-17 00:50] falls asleep
        [1518-07-14 00:00] Guard #1889 begins shift
        [1518-10-12 00:53] wakes up
        [1518-10-14 00:54] wakes up
        [1518-09-18 00:46] wakes up
        [1518-08-05 00:40] falls asleep
        [1518-05-30 00:57] wakes up
        [1518-07-20 00:00] Guard #467 begins shift
        [1518-11-08 23:58] Guard #3121 begins shift
        [1518-05-30 00:24] falls asleep
        [1518-06-15 00:51] wakes up
        [1518-04-11 00:57] falls asleep
        [1518-05-08 00:40] wakes up
        [1518-04-07 00:06] wakes up
        [1518-04-26 00:03] falls asleep
        [1518-05-07 00:47] wakes up
        [1518-05-26 00:40] wakes up
        [1518-06-13 00:31] falls asleep
        [1518-06-08 00:28] wakes up
        [1518-05-27 00:37] falls asleep
        [1518-06-28 00:58] wakes up
        [1518-09-10 00:58] wakes up
        [1518-09-19 00:56] wakes up
        [1518-11-18 00:04] Guard #467 begins shift
        [1518-11-22 00:50] wakes up
        [1518-07-11 00:07] wakes up
        [1518-05-26 00:44] falls asleep
        [1518-09-06 00:15] falls asleep
        [1518-07-08 00:43] wakes up
        [1518-07-10 00:03] Guard #3491 begins shift
        [1518-05-07 00:29] wakes up
        [1518-11-03 00:49] wakes up
        [1518-06-11 00:44] wakes up
        [1518-10-11 00:04] Guard #661 begins shift
        [1518-06-15 23:56] Guard #61 begins shift
        [1518-07-06 00:22] wakes up
        [1518-11-08 00:43] wakes up
        [1518-10-11 00:19] falls asleep
        [1518-10-10 00:02] Guard #3037 begins shift
        [1518-06-17 00:37] falls asleep
        [1518-08-13 00:43] falls asleep
        [1518-09-24 00:47] wakes up
        [1518-10-23 00:01] Guard #409 begins shift
        [1518-05-30 00:04] Guard #3307 begins shift
        [1518-05-21 00:18] wakes up
        [1518-09-15 00:55] wakes up
        [1518-06-14 00:13] falls asleep
        [1518-05-13 00:41] wakes up
        [1518-06-02 00:20] falls asleep
        [1518-04-16 00:48] falls asleep
        [1518-08-24 00:20] falls asleep
        [1518-07-31 00:03] Guard #3491 begins shift
        [1518-06-27 00:42] falls asleep
        [1518-09-28 00:44] falls asleep
        [1518-10-09 00:01] Guard #2897 begins shift
        [1518-10-16 00:13] falls asleep
        [1518-04-22 23:56] Guard #409 begins shift
        [1518-10-30 00:10] falls asleep
        [1518-11-11 00:04] Guard #2819 begins shift
        [1518-04-12 00:58] wakes up
        [1518-05-03 00:33] wakes up
        [1518-11-03 00:44] falls asleep
        [1518-11-03 23:48] Guard #1433 begins shift
        [1518-05-23 00:04] Guard #661 begins shift
        [1518-05-24 00:49] falls asleep
        [1518-06-04 23:58] Guard #467 begins shift
        [1518-11-23 00:19] falls asleep
        [1518-06-27 00:04] Guard #947 begins shift
        [1518-08-29 00:51] falls asleep
        [1518-10-04 00:09] falls asleep
        [1518-05-18 00:48] wakes up
        [1518-05-25 00:08] falls asleep
        [1518-11-23 00:56] wakes up
        [1518-08-23 00:26] wakes up
        [1518-11-16 00:46] wakes up
        [1518-07-20 00:40] wakes up
        [1518-06-06 00:41] falls asleep
        [1518-05-28 00:47] wakes up
        [1518-06-25 00:31] falls asleep
        [1518-04-11 00:54] wakes up
        [1518-10-11 00:53] falls asleep
        [1518-11-19 23:58] Guard #1471 begins shift
        [1518-08-07 00:50] falls asleep
        [1518-07-21 00:55] wakes up
        [1518-08-17 00:43] falls asleep
        [1518-08-07 23:56] Guard #1283 begins shift
        [1518-04-21 00:13] falls asleep
        [1518-08-18 00:01] Guard #419 begins shift
        [1518-07-21 00:24] wakes up
        [1518-05-04 00:21] falls asleep
        [1518-10-03 00:31] wakes up
        [1518-08-09 00:42] wakes up
        [1518-07-27 23:59] Guard #947 begins shift
        [1518-09-10 00:20] wakes up
        [1518-04-26 00:22] wakes up
        [1518-04-13 23:58] Guard #661 begins shift
        [1518-09-30 00:52] wakes up
        [1518-06-10 00:59] wakes up
        [1518-10-14 00:00] falls asleep
        [1518-09-14 00:21] falls asleep
        [1518-10-04 00:46] wakes up
        [1518-05-31 00:37] wakes up
        [1518-10-20 00:14] falls asleep
        [1518-11-09 00:29] falls asleep
        [1518-06-18 00:55] wakes up
        [1518-09-18 23:51] Guard #2819 begins shift
        [1518-08-30 00:56] wakes up
        [1518-06-21 00:36] wakes up
        [1518-10-10 00:32] falls asleep
        [1518-08-20 23:51] Guard #409 begins shift
        [1518-04-05 00:33] wakes up
        [1518-10-29 00:00] Guard #3121 begins shift
        [1518-11-23 00:04] Guard #1663 begins shift
        [1518-05-15 00:43] wakes up
        [1518-09-03 00:50] wakes up
        [1518-05-09 00:46] falls asleep
        [1518-07-19 00:09] falls asleep
        [1518-05-10 00:02] Guard #409 begins shift
        [1518-07-04 23:56] Guard #1931 begins shift
        [1518-08-24 00:23] wakes up
        [1518-09-25 00:01] falls asleep
        [1518-09-27 00:17] falls asleep
        [1518-07-02 23:58] Guard #1931 begins shift
        [1518-09-23 00:53] wakes up
        [1518-07-04 00:46] wakes up
        [1518-05-17 00:17] wakes up
        [1518-05-09 00:50] falls asleep
        [1518-10-19 00:59] wakes up
        [1518-10-18 00:36] falls asleep
        [1518-11-04 00:05] falls asleep
        [1518-07-18 00:16] falls asleep
        [1518-08-12 00:27] wakes up
        [1518-08-28 00:03] Guard #3121 begins shift
        [1518-06-24 00:03] Guard #1291 begins shift
        [1518-06-08 00:50] wakes up
        [1518-08-22 00:00] Guard #3491 begins shift
        [1518-07-07 00:45] wakes up
        [1518-04-17 00:04] Guard #947 begins shift
        [1518-07-26 00:00] falls asleep
        [1518-08-19 23:46] Guard #3307 begins shift
        [1518-11-13 00:58] wakes up
        [1518-08-10 00:02] Guard #1663 begins shift
        [1518-05-21 00:36] wakes up
        [1518-11-18 00:44] falls asleep
        [1518-11-08 00:10] wakes up
        [1518-10-15 23:56] Guard #2447 begins shift
        [1518-04-07 23:50] Guard #2897 begins shift
        [1518-11-04 00:16] wakes up
        [1518-11-14 00:28] falls asleep
        [1518-09-11 00:36] wakes up
        [1518-06-28 00:31] wakes up
        [1518-11-10 00:10] falls asleep
        [1518-04-15 00:31] falls asleep
        [1518-05-29 00:11] falls asleep
        [1518-06-24 00:44] wakes up
        [1518-07-21 00:44] wakes up
        [1518-09-14 00:38] falls asleep
        [1518-04-05 00:40] falls asleep
        [1518-08-10 00:49] wakes up
        [1518-07-16 00:02] Guard #2447 begins shift
        [1518-10-02 23:58] Guard #409 begins shift
        [1518-07-17 00:53] wakes up
        [1518-06-07 23:59] Guard #61 begins shift
        [1518-08-15 00:56] wakes up
        [1518-04-18 00:02] Guard #3037 begins shift
        [1518-06-04 00:57] falls asleep
        [1518-06-19 00:44] wakes up
        [1518-05-14 00:04] Guard #1433 begins shift
        [1518-04-22 00:18] falls asleep
        [1518-10-07 00:09] falls asleep
        [1518-10-23 00:16] wakes up
        [1518-05-06 00:37] falls asleep
        [1518-06-09 00:34] wakes up
        [1518-04-27 00:47] wakes up
        [1518-04-08 23:47] Guard #1291 begins shift
        [1518-04-05 00:41] wakes up
        [1518-07-11 00:04] falls asleep
        [1518-11-12 00:22] falls asleep
        [1518-08-11 00:44] wakes up
        [1518-09-09 00:35] falls asleep
        [1518-06-03 00:48] falls asleep
        [1518-10-18 00:01] Guard #947 begins shift
        [1518-04-21 00:41] falls asleep
        [1518-05-19 00:34] wakes up
        [1518-10-09 00:47] falls asleep
        [1518-09-28 00:52] wakes up
        [1518-07-08 00:59] wakes up
        [1518-09-12 23:49] Guard #61 begins shift
        [1518-10-10 00:56] wakes up
        [1518-08-10 00:33] falls asleep
        [1518-09-07 00:09] falls asleep
        [1518-10-26 00:02] Guard #61 begins shift
        [1518-09-08 00:14] falls asleep
        [1518-05-01 23:58] Guard #947 begins shift
        [1518-10-29 23:58] Guard #2459 begins shift
        [1518-11-13 00:57] falls asleep
        [1518-09-30 00:58] wakes up
        [1518-05-28 00:24] falls asleep
        [1518-07-05 00:25] falls asleep
        [1518-06-18 00:45] wakes up
        [1518-11-18 00:54] wakes up
        [1518-09-23 23:59] Guard #1291 begins shift
        [1518-07-22 23:59] Guard #61 begins shift
        [1518-09-17 00:12] falls asleep
        [1518-09-11 00:21] falls asleep
        [1518-05-05 00:27] falls asleep
        [1518-11-21 00:00] Guard #1471 begins shift
        [1518-09-28 00:12] wakes up
        [1518-07-09 00:22] falls asleep
        [1518-05-03 00:02] Guard #947 begins shift
        [1518-09-01 00:36] wakes up
        [1518-07-20 23:56] Guard #2633 begins shift
        [1518-07-19 00:43] falls asleep
        [1518-09-21 00:31] wakes up
        [1518-11-19 00:27] falls asleep
        [1518-04-18 00:23] falls asleep
        [1518-04-28 00:03] falls asleep
        [1518-11-02 23:57] Guard #947 begins shift
        [1518-04-16 00:34] falls asleep
        [1518-04-14 00:28] falls asleep
        [1518-11-01 23:57] Guard #2459 begins shift
        [1518-07-22 00:57] wakes up
        [1518-04-17 00:58] wakes up
        [1518-09-21 00:43] falls asleep
        [1518-04-07 00:58] wakes up
        [1518-08-13 23:56] Guard #1291 begins shift
        [1518-11-08 00:08] falls asleep";

        //readonly string _input = @"[1518-11-01 00:00] Guard #10 begins shift
        //[1518-11-01 00:05] falls asleep
        //[1518-11-01 00:25] wakes up
        //[1518-11-05 00:03] Guard #99 begins shift
        //[1518-11-01 00:30] falls asleep
        //[1518-11-01 00:55] wakes up
        //[1518-11-01 23:58] Guard #99 begins shift
        //[1518-11-02 00:40] falls asleep
        //[1518-11-04 00:46] wakes up
        //[1518-11-04 00:02] Guard #99 begins shift
        //[1518-11-02 00:50] wakes up
        //[1518-11-04 00:36] falls asleep
        //[1518-11-03 00:05] Guard #10 begins shift
        //[1518-11-03 00:24] falls asleep
        //[1518-11-03 00:29] wakes up
        //[1518-11-04 00:02] Guard #99 begins shift
        //[1518-11-05 00:45] falls asleep
        //[1518-11-05 00:55] wakes up"

        Dictionary<int, GuardShift> _shiftHours;

        private string[] GetLines()
        {
            var lines = _input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Array.Sort(lines, (a, b) =>
            {
                DateTime da = GetDate(a);
                DateTime db = GetDate(b);
                if (da < db) return -1;
                else if (da > db) return 1;
                else return 0;
            });

            return lines;
        }
        private static bool IsNewShift(string line) => line.EndsWith("begins shift");
        private static bool IsFallsAsleep(string line) => line.EndsWith("falls asleep");

        private static DateTime GetDate(string line)
        {
            Regex regex = new(@"\[(\d{4}-\d{2}-\d{2} \d{2}:\d{2})\]");
            Match match;
            if ((match = regex.Match(line)) != null)
            {
                return DateTime.ParseExact(match.Groups[1].ToString(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            return DateTime.MinValue;
        }

        private static Event GetShift(string line)
        {
            Regex regex = new(@"\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\] Guard #(\d+) begins shift");
            Match match;
            if((match = regex.Match(line)) != null)
            {
                return new Event(int.Parse(match.Groups[2].ToString()));
            }
            return null;
        }
        private static int GetTime(string line)
        {
            Regex regex = new(@"\[\d{4}-\d{2}-\d{2} \d{2}:(\d{2})\]");
            Match match;
            if ((match = regex.Match(line)) != null)
            {
                return int.Parse(match.Groups[1].ToString());
            }
            return -1;
        }

        private void GetValues()
        {
            var lines = GetLines();

            _shiftHours = new Dictionary<int, GuardShift>();
            int currentGuard = 0;
            int sleepStart = 0;
            foreach (string line in lines)
            {
                if (IsNewShift(line))
                {
                    var s = GetShift(line);
                    currentGuard = s.GuardId;
                    if (!_shiftHours.TryGetValue(s.GuardId, out GuardShift shift))
                    {
                        shift = new GuardShift();
                        _shiftHours.Add(s.GuardId, shift);
                    }
                }
                else
                {
                    int minute = GetTime(line);

                    if (IsFallsAsleep(line))
                    {
                        sleepStart = minute;
                    }
                    else
                    {
                        var shift = _shiftHours[currentGuard];
                        while (sleepStart < minute)
                        {
                            if (!shift.SleepMinutes.TryGetValue(sleepStart, out int count))
                            {
                                shift.SleepMinutes.Add(sleepStart, 0);
                            }
                            shift.SleepMinutes[sleepStart]++;
                            sleepStart++;
                        }
                    }
                }
            }
        }

        public string Task1()
        {
            GetValues();

            int guardId = 0, minutesSlept = 0;
            foreach(var g in _shiftHours)
            {
                if(g.Value.TotalMinutes > minutesSlept)
                {
                    guardId = g.Key;
                    minutesSlept = g.Value.TotalMinutes;
                }
            }

            var guard = _shiftHours[guardId];
            int mostCommonMinute = guard.MostCommonMinute().Minute;
            int result = guardId * mostCommonMinute;

            return result.ToString();
        }

        public string Task2()
        {
            GetValues();

            int guardId = 0;
            (int Minute, int Count) mostCommon = (0, 0);
            foreach (var g in _shiftHours)
            {
                var mostCommonMinute = g.Value.MostCommonMinute();
                if (mostCommonMinute.Count > mostCommon.Count)
                {
                    guardId = g.Key;
                    mostCommon = mostCommonMinute;
                }
            }

            int result = guardId * mostCommon.Minute;

            return result.ToString();
        }

        class Event
        {
            public int GuardId;

            public Event(int guardId)
            {
                GuardId = guardId;
            }
        }

        class GuardShift
        {
            public SortedDictionary<int, int> SleepMinutes;
            public GuardShift()
            {
                SleepMinutes = new SortedDictionary<int, int>();
            }

            public int TotalMinutes => SleepMinutes.Values.Sum();
            public (int Minute, int Count) MostCommonMinute()
            {
                if (SleepMinutes.Count == 0) return (-1, 0);
                KeyValuePair<int, int> highest = SleepMinutes.First();
                foreach(var pair in SleepMinutes)
                {
                    if(pair.Value > highest.Value)
                    {
                        highest = pair;
                    }
                }
                return (highest.Key, highest.Value);
            }
        }
    }
}
