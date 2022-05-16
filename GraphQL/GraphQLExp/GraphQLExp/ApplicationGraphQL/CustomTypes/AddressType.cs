using GraphQL.Types;
using GraphQLExp.Models;

namespace GraphQLExp.ApplicationGraphQL.CustomTypes
{
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(t => t.AddressID);
            Field(t => t.AddressLine1);
            Field(t => t.AddressLine2);
            Field(t => t.City);
            Field(t => t.Country);
            Field(t => t.State);
            Field(t => t.Pincode);
        }
    }
}
