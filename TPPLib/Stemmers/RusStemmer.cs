using System;
using System.Text.RegularExpressions;

namespace TPPLib.Stemmers
{
	/// <summary>
	/// Стеммер для русского языка.
	/// За основу взят вот этот - http://www.algorithmist.ru/2010/12/porter-stemmer-russian.html , в основе которого
	/// вот этот  - http://forum.dklab.ru/php/advises/HeuristicWithoutTheDictionaryExtractionOfARootFromRussianWord.html , в 
	/// основе которого вот этот алгоритм - search.cpan.org/~algdr/Lingua-Stem-Ru/Ru.pm .
	/// </summary>
	public class RusStemmer : AbstractStemmer
    {
        private Regex PERFECTIVEGROUND = new Regex("((ив|ивши|ившись|ыв|ывши|ывшись)|((?<=[ая])(в|вши|вшись)))$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex REFLEXIVE = new Regex("(с[яь])$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex ADJECTIVE = new Regex("(ее|ие|ые|ое|ими|ыми|ей|ий|ый|ой|ем|им|ым|ом|его|ого|ему|ому|их|ых|ую|юю|ая|яя|ою|ею)$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex PARTICIPLE = new Regex("((ивш|ывш|ующ)|((?<=[ая])(ем|нн|вш|ющ|щ)))$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex VERB = new Regex("((ила|ыла|ена|ейте|уйте|ите|или|ыли|ей|уй|ил|ыл|им|ым|ен|ило|ыло|ено|ят|ует|уют|ит|ыт|ены|ить|ыть|ишь|ую|ю)|((?<=[ая])(ла|на|ете|йте|ли|й|л|ем|н|ло|но|ет|ют|ны|ть|ешь|нно)))$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex NOUN = new Regex("(а|ев|ов|ие|ье|е|иями|ями|ами|еи|ии|и|ией|ей|ой|ий|й|иям|ям|ием|ем|ам|ом|о|у|ах|иях|ях|ы|ь|ию|ью|ю|ия|ья|я)$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex RVRE = new Regex("^(.*?[аеиоуыэюя])(.*)$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex DERIVATIONAL = new Regex(".*[^аеиоуыэюя]+[аеиоуыэюя].*ость?$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex DER = new Regex("ость?$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex SUPERLATIVE = new Regex("(ейше|ейш)$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);

        private Regex I = new Regex("и$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private Regex P = new Regex("ь$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private Regex NN = new Regex("нн$", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);


        public override string Stem(string word)
        {
            word = word.ToLower();
            word = word.Replace('ё', 'е');
            if (RVRE.IsMatch(word))
			{
                String pre = RVRE.Matches(word)[0].Groups[1].Value;
				String rv = RVRE.Matches(word)[0].Groups[2].Value;
                String temp = PERFECTIVEGROUND.Replace(rv,"",1);
				if (temp == rv)
				{
                    rv = REFLEXIVE.Replace(rv,"",1);
                    temp = ADJECTIVE.Replace(rv,"",1);
					if (temp != rv)
					{
						rv = temp;
                        rv = PARTICIPLE.Replace(rv,"",1);
					}
					else
					{
                        temp = VERB.Replace(rv,"",1);
						if (temp == rv)
						{
                            rv = NOUN.Replace(rv,"",1);
						}
						else
						{
							rv = temp;
						}
					}

				}
				else
				{
					rv = temp;
				}

                rv = I.Replace(rv,"",1);

                if (DERIVATIONAL.IsMatch(rv))
				{
                    rv = DER.Replace(rv,"", 1);
				}

                temp = P.Replace(rv,"",1);
				if (temp == rv)
				{
                    rv = SUPERLATIVE.Replace(rv,"", 1);
                    rv = NN.Replace(rv,"н", 1);
				}
				else
				{
					rv = temp;
				}
				word = pre + rv;

			}

			return word;
        }
    }
}
