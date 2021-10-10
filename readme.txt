/// This demo is for :

  Stateful WCF communication using ASP.NET Compatibility Model
  N-tier web application using load balancing

/// How to install

1. Install NLB and session database
2. Modify sessionState database connection string in web.config at AspNetCompatiSvc and AspNetCompatiClient
3. Modify service endpoint address in web.config at AspNetCompatiClient
  (Use load balancing virtual address)
4. copy AspNetCompatiSvc and AspNetCompatiClient

You can see load balancing web client and WCF service.
