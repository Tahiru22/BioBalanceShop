document.addEventListener("DOMContentLoaded", function () {
    fetch('/Payment/GetStripeKey')
        .then(response => response.json())
        .then(data => {
            var stripe = Stripe(data.publishableKey);
            var elements = stripe.elements();

            var card = elements.create('card', {
                style: {
                    base: {
                        fontSize: '16px',
                        lineHeight: '1.5',
                        '::placeholder': {
                            color: '#aab7c4'
                        }
                    }
                },
                hidePostalCode: true
            });

            card.mount('#card-element');

            var form = document.getElementById('payment-form');
            form.addEventListener('submit', function (event) {
                event.preventDefault();

                stripe.createToken(card).then(function (result) {
                    if (result.error) {
                        var errorElement = document.getElementById('card-errors');
                        errorElement.textContent = result.error.message;
                    } else {
                        stripeTokenHandler(result.token);
                    }
                });
            });

            function stripeTokenHandler(token) {
                var form = document.getElementById('payment-form');

                var tokenId = document.createElement('input');
                tokenId.setAttribute('type', 'hidden');
                tokenId.setAttribute('name', 'stripeToken');
                tokenId.setAttribute('value', token.id);
                form.appendChild(tokenId);

                form.submit();
            }
        })
        .catch(error => console.error('Error:', error));
});

