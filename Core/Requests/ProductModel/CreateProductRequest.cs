
using Core.Constants;
using Core.Entities;
using Core.Requests.AccountModel.AccountTypesModel;
using Core.Requests.CreditCardModel;


namespace Core.Requests.ProductModel;

    //necessary to create

public class CreateProductRequest
{

    
    public ProductType Type { get; set; }
    public DateTime ApplicationDate { get; } = DateTime.Today;



    //public DateTime ApprovalDate
    //{
    //    get { return _date.Date; }
    //    set { _date = value.Date; }
    //}

    //the current type that the product will have
    public Currency Currency { get; set; } = new Currency();


    //depending on which product type we choose, it will use one of this attributes
    public CreateCreditCardModel? CreditCard { get; set; }
    public CreateCurrentAccount? CurrentAccount { get; set; }
    public CreateCreditOnly? CreditOnly { get; set; }
}
