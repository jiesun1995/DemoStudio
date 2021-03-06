﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace voiceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var speech = new SpeechSynthesizer();
            string str = @"正方论点
首先想让大家看一句数据。
正处于恋爱阶段或曾谈过恋爱85 %
现在未谈，并不表示以后不谈9 %
抵触大学生恋爱6 %
大学生恋爱在各高校已是普遍现象
因此，我们更不因该去阻止，应该允许。z
恋爱是两个人人格的深层接触，在此过程中，青年的自我概念受到对方的影响而发展，真正懂得了如何在保持自身独立性的前提下调整自身缺陷以适应对方。也就是说，经过了爱情，恋爱对一些个性因素和社会情感发展有重大意义。并且恋爱中两人的深层交往为提高青年交际能力，适应以后的社会打下了基础。
对于经过高等教育的大学生而言，恋爱是两个人学习的调剂。同时大学时代的恋爱很少有金钱的困扰，世俗的虚伪是比较真挚单纯的。为了在爱人面前表现得更出色，很多大学生在各方面都取得了进步。
但是如果我们不站在时代的前列，一味强调大学生恋爱的个别弊端而忽视了大学生恋爱对身心成熟发展的重要意义。控制甚至禁止大学生恋爱则会激发他们更大的好奇。物极必反，扭曲和误导大学生的恋爱观，使他们误入歧途。从而影响其今后的发展和生活。导致严重的后果。所以我们不能愚昧，片面地强调恋爱的个别弊端，这种一叶障目的做法是不可取的。
综上所述，我们只有正视大学生这一特殊阶段，尊重学生的心理需求。看到大学生恋爱对其发展的重要性，正确引导，并承认大学生恋爱利大于弊。才能与时俱进，求得发展。";
            speech.Speak(str);

            Console.ReadLine();
        }
    }
}
