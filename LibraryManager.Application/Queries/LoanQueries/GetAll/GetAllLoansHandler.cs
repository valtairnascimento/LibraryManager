﻿using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using MediatR;

namespace LibraryManager.Application.Queries.LoanQueries.GetAll
{
    public class GetAllLoansHandler : IRequestHandler<GetAllLoansQuery, ResultViewModel<List<LoanViewModel>>>
    {
        private readonly ILoanRepository _repository;
        public GetAllLoansHandler(ILoanRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultViewModel<List<LoanViewModel>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var loan = await _repository.GetAll();

            var model = loan.Select(LoanViewModel.FromEntity).ToList();

            return ResultViewModel<List<LoanViewModel>>.Success(model);
        }
    }
    
}
