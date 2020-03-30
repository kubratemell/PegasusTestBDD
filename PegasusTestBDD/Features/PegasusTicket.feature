Feature: PegasusTicket
	

@mytag
Scenario: Pegasus Ticket
	* '//*[@id="nxm2CookieSubmitButton"]' alanına tıklanır.
	* '.nxm2_select-nereden .select2-selection--single' alanına tıkla.
	* '.select2-search__field' alanına 'İstanbul-' yaz.
	* '.nxm2_select-nereye .select2-selection--single' alanına tıkla.
	* '.select2-search__field' alanına 'Amsterdam' yaz.
	* '#dp1' alanına tıkla.
	* 'Gidiş' alanına '2.Ağustos.2020' girilir.
	* 'Dönüş' alanına '6.Ocak.2021' girilir.
	* '#fligth-searh .nxm2_btn-dark_orange' alanına tıkla.
	* '.departure-list .availability-list-item-content' alanına tıkla.
	* '.departure-list .package-card  ~div ~div ~div .currency-info-element-container' alanına tıkla.
	* '.return-list .availability-list-item-content' alanına tıkla.
	* '.return-list .package-card ~div ~div ~div .currency-info-element-container' alanına tıkla.
	* '2' saniye süreyle beklenir
	* '.action-buttons .submit-button' alanına tıkla.
	* '.name input' alanına tıkla.
	* '.name input' alanına 'Kübra' yaz.
	* '.surname input' alanına tıkla.
	* '.surname input' alanına 'Temel' yaz.
	* '.passenger-birthday-wrapper .date-text-input div input' alanına '16' yaz.
	* '.passenger-birthday-wrapper .date-text-input div ~div input' alanına '01' yaz.
	* '.passenger-birthday-wrapper .date-text-input div ~div ~div input' alanına '1998' yaz.
	* '.field-wrapper .gender div input' alanına tıkla.
	* '.phone-wrapper .number-container .tr-area input' alanına '555' yaz.
	* '.phone-wrapper .number-container .phone-number input' alanına '5555555' yaz.
	* '.tckn input' alanına '11111111111' yaz.
	* '.info-form-submit-button' alanına tıkla.
	* '.email input' alanına 'kubra@gmail.com' yaz.
	* '3' saniye süreyle beklenir
	* '.info-form-submit-button' alanına tıkla.
	* '3' saniye süreyle beklenir
	* '5' saniye süreyle beklenir
	