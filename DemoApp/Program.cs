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
            var texts = new List<Token>()
            {
               new RawText
               {
                   TextId = "1",
                   Content = "Это вот какой-то первый текст... Просто тупо текстик какой-то! abc@mail.ru"
               },
               new RawText
               {
                   TextId = "2",
                   Content = "<bold>А  это вот</bold> какой-то второй текст... http://hahaha.ru Ужне значительно интереснее!"
               },new RawText
               {
                   TextId = "3",
                   Content = "Ну и на последок третий текст! Вот так. Оп"
               }
            };

            var cleaner = new BasicTextCleaner();
            var tokenizer = new RusTokenizer();
            
            List<TPPOperation> ops = new List<TPPOperation>()
            {
                new RemoveEmails(),
                new RemoveLinks(),
                new RemoveHtmlAndJs(),
            };

            var @operator = new TPPOperator(texts, ops);

            foreach (var t in texts)
            {                
                @operator.Exucute();                
            }

            texts = cleaner.MakeBasicCleaning(texts).Select(to => (Token)to).ToList();

            ops = new List<TPPOperation>()
            {               
                new RemoveShortWords(),
                new RemovePunctuation(),
                new RemoveStopWords(true, false),
                new MakeStemming(new RusStemmer())
            };

            foreach (var t in texts)
            {
                t.Tokens = tokenizer.TokenizeToWords(t).Select(to => (Token)to).ToList();
                @operator = new TPPOperator(t.Tokens, ops);
                @operator.Exucute();
                t.Tokens = cleaner.MakeBasicCleaning(t.Tokens).Select(to => (Token)to).ToList();
            };

            Console.ReadLine();
        }
    }
}
