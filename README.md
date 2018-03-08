<h1>Session Configuration in ASP.NET</h1>
We use session state to write and read values as the users navigate ASP.NET pages. ASP.NET session state identifies requests from the same browser during a limited time window as a session and provides a way to persist variable values for the duration of that session. Below are the steps required to set up and configure session state for an ASP.NET project.
<!--more-->

<strong>MODIFY THE PROJECT CONFIGURATION</strong>

Within your ASP.NET project, navigate to <strong><em>Web.config</em></strong> file. Insert the below <strong>sessionState</strong> element into <strong>&lt;system.web&gt;</strong> tag.
<code><pre>
&lt;sessionState mode="SQLServer"
  cookieless="true"
  regenerateExpiredSessionId="true"
  timeout="30"
  sqlConnectionString="Data Source=YOUR-DB-SOURCE;Integrated Security=SSPI;"
  stateNetworkTimeout="30"/&gt;
</pre></code>
<ul>
 	<li><strong>mode</strong>: Specify where to store the value. Here we use "SQLServer"
to store the session state into our local database.</li>
 	<li><strong>cookieless</strong>: An optional HttpCookieMode attribute. It specifies how cookies are used for this web application.</li>
 	<li><strong>regenerateExpiredSessionId</strong>: An optional boolean value. It specifies whether a new SessionId should be issued when an expired SessionId is detected.</li>
 	<li><strong>timeout</strong>: The number of minutes before before SessionID is expired.</li>
 	<li><strong>sqlConnectionString</strong>: SQL Server configuration string of your local database.</li>
 	<li><strong>stateNetworkTimeout</strong>: Specifies the number of seconds that the TCP/IP network connection between the Web server and the state server can be idle before the request is canceled.</li>
</ul>
<strong>ADD ASPSTATE DATABASE INTO YOUR SQL SERVER</strong>

As we want to store our session state into SQL Server, a new database (default named ASPState) needs to be added to handle session values. To add ASPState database into your SQL Server, open cmd prompt and execute the below command.

<code><pre>
C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\aspnet_regsql -S YOUR-DB-SOURCE -ssadd -sstype p -E
</pre></code>

If any error is thrown here, please verify that:
	<li>you are running cmd prompt in administrator mode.</li>
	<li>your database source name is correct.</li>
	<li>your datbase has been configured to allow remote conectivity.</li>
	<li>your database connection is not blocked by Windows firewall.</li>
	<li>asp.net_regsql path matches with your .NET installation path.</li>
<br/>
<strong>WRITE VALUES TO SESSION</strong>

After those steps above, we have had our Session State set up. Now it's time to test if the Session object is working properly. The Session object supports a dynamic associative array that a script can use to store information. This example uses the <strong>HttpSessionState</strong> object to persist values within an individual session.

<code><pre>
<span></span><span class="kt">string</span> <span class="n">firstName</span> <span class="p">=</span> <span class="s">&quot;John&quot;</span><span class="p">;</span>
<span class="kt">string</span> <span class="n">lastName</span> <span class="p">=</span> <span class="s">&quot;Doe&quot;</span><span class="p">;</span>
<span class="kt">string</span> <span class="n">city</span> <span class="p">=</span> <span class="s">&quot;Melbourne&quot;</span><span class="p">;</span>
<span class="n">Session</span><span class="p">[</span><span class="s">&quot;FirstName&quot;</span><span class="p">]</span> <span class="p">=</span> <span class="n">firstName</span><span class="p">;</span>
<span class="n">Session</span><span class="p">[</span><span class="s">&quot;LastName&quot;</span><span class="p">]</span> <span class="p">=</span> <span class="n">lastName</span><span class="p">;</span>
<span class="n">Session</span><span class="p">[</span><span class="s">&quot;City&quot;</span><span class="p">]</span> <span class="p">=</span> <span class="n">city</span><span class="p">;</span>
</pre></code>

<strong>READ VALUES TO SESSION</strong>

<code><pre>
<span class="kt">string</span> <span class="n">firstName</span> <span class="p">=</span> <span class="p">(</span><span class="kt">string</span><span class="p">)(</span><span class="n">Session</span><span class="p">[</span><span class="s">&quot;First&quot;</span><span class="p">]);</span>
<span class="kt">string</span> <span class="n">lastName</span> <span class="p">=</span> <span class="p">(</span><span class="kt">string</span><span class="p">)(</span><span class="n">Session</span><span class="p">[</span><span class="s">&quot;Last&quot;</span><span class="p">]);</span>
<span class="kt">string</span> <span class="n">city</span> <span class="p">=</span> <span class="p">(</span><span class="kt">string</span><span class="p">)(</span><span class="n">Session</span><span class="p">[</span><span class="s">&quot;City&quot;</span><span class="p">]);</span>
</pre></code>

<strong>REFERENCES</strong>
<a href="https://msdn.microsoft.com/en-us/library/ms178581.aspx">Microsoft MSDN - ASP.NET Session State Overview</a>
<a href="https://msdn.microsoft.com/en-us/library/ms178586.aspx">Microsoft MSDN - Session-State Modes</a>

<em><strong>Read More: </strong></em> <a href="https://raydeveloperonline.com/2018/02/15/session/" rel="noopener" target="_blank">Ray's Blog - Session Configuration in ASP.NET</a>
