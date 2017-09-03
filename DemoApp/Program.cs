using System;
using System.Collections.Generic;
using TPPLib;
using TPPLib.Entities;
using TPPLib.Tokenizers;
using System.Linq;
using TPPLib.TPPOperations;
using TPPLib.Stemmers;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<RawText> texts = new List<RawText>()
            {
               new RawText
               {
                   Id = "1",
                   Content = "Это вот какой-то первый текст... Просто тупо текстик какой-то! abc@mail.ru"
               },
               new RawText
               {
                   Id = "2",
                   Content = "<bold>А  это вот</bold> какой-то второй текст... http://hahaha.ru Ужне значительно интереснее!"
               },new RawText
               {
                   Id = "3",
                   Content = "Ну и на последок третий текст! Вот так. Оп"
               }
            };

            var tokenizer = new RusTokenizer();
            BasicTextCleaner cleaner = new BasicTextCleaner();
            List<TPPOperation> ops = new List<TPPOperation>()
            {
                new RemoveEmails(),
                new RemoveLinks(),
                new RemoveHtmlAndJs(),
                new RemoveShortWords(),
                new RemovePunctuation(),
                new RemoveStopWords(true, false),
                new MakeStemming(new RusStemmer())
            };

            foreach (var t in texts)
            {
                cleaner.MakeBasicCleaning(t);
                t.Tokens = tokenizer.TokenizeToWords(t).Select(to => (Token)to).ToList();

                TPPOperator @operator = new TPPOperator(t.Tokens, ops);
                @operator.Exucute();
                t.Tokens = cleaner.MakeBasicCleaning(t.Tokens).ToList();
            };

            Console.ReadLine();
        }
    }
}
