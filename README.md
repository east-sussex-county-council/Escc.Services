Escc.Services
=============

A service container and basic implementations of common services used by applications, such as email. 

A [NuBuild](https://github.com/bspell1/NuBuild) project is used to create the NuGet package.

Email
-----

**C#** 

In this example configuration settings come from web.config or app.config, but they could come from any `IServiceRegistry`. The ASP.NET application cache is being used to avoid recreating the email service, but this could be any `IServiceCacheStrategy` or none.

	var email = new MailMessage("alice@example.org", "bob@example.org", "subject", "body");
	var configuration = new ConfigurationServiceRegistry();
	var cache = new HttpContextCacheStrategy();

	var emailService = ServiceContainer.LoadService<IEmailService>(configuration, cache);

    emailService.Send(email); 

**web.config**

	<configuration>
	  <configSections>
	    <sectionGroup name="Escc.Services">
	      <section name="ServiceRegistry" type="System.Configuration.NameValueSectionHandler, System, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
	    </sectionGroup>
	  </configSections>
	  
	  <Escc.Services>
	    <ServiceRegistry>
	      <add key="Escc.Services.IEmailSender" value="Escc.Services.SmtpEmailSender, Escc.Services" />
	    </ServiceRegistry>
	  </Escc.Services>
	
	 <system.net>
	    <mailSettings>
	      <smtp>
	        <network host="IP of SMTP server" />
	      </smtp>
	    </mailSettings>
	  </system.net>
	</configuration>