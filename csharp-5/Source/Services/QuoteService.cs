using Codenation.Challenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;
        private List<Quote> list;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            _context = context;
            _randomService = randomService;
            list = _context.Quotes.ToList();
        }

        public Quote GetAnyQuote()
        {
            var numero = _randomService.RandomInteger(_context.Quotes.Count());
            return list.ElementAtOrDefault(numero);
        }

        public Quote GetAnyQuote(string actor)
        {
            var quotes = list.Where(x => x.Actor == actor);
            var numero = _randomService.RandomInteger(_context.Quotes.Count());
            return quotes.ElementAtOrDefault(numero);
        }
    }
}