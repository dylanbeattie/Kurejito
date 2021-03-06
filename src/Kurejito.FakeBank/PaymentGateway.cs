﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kurejito.Gateway;
using Kurejito.Payments;

namespace Kurejito.FakeBank {
	/// <summary>
	/// Provides a fake, in-memory, stateless simulated payment provider for testing code that uses a <see cref="Kurejito.IPaymentGateway" />.
	/// </summary>
	public class PaymentGateway : IPaymentGateway {
		public PaymentResponse Purchase(Money money, CreditCard creditCard) {
			if (money.Amount > 10.0m) {
				return(new PaymentResponse() { 
					Status = PaymentStatus.Declined, 
					StatusDetail = "Sorry - FakeBank only accepts transactions under a tenner!" 
				});
			}

			return(new PaymentResponse() {
				Status = PaymentStatus.OK,
				StatusDetail = "Payment successful"
			});
		}
	}
}
