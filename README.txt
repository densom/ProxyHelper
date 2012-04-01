PROJECT DESCRIPTION:

This program allows you to retrieve a URL without having to specify your proxy.  You configure the web site in this project to work with your proxy.  Then, you pass a URL parameter of the actual external URL you want to retrieve.  This is useful when you need to work with a program that does not allow
you to specify a URL.

EXAMPLE:
http://localhost/ProxyHelper/GetUrl.aspx?url=http://www.google.com/


SETUP:
Edit the .\ProxyHelper\web.config file and add your proxy URL, username and password.

  <appSettings>
    <add key="ProxyUrl" value="http://your-proxy.your-domain.com:8080"/>
    <add key="ProxyUser" value="[enter proxy user name]"/>
    <add key="ProxyPassword" value="[enter proxy password]"/>
  </appSettings>


