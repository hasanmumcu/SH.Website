
//using microsoft.aspnetcore.http;
//using microsoft.aspnetcore.ıdentity;
//using microsoft.aspnetcore.mvc;
//using microsoft.extensions.configuration;
//using microsoft.ıdentitymodel.tokens;
//using sh.website.authentication;
//using sh.website.models;
//using system;
//using system.collections.generic;
//using system.ıdentitymodel.tokens.jwt;
//using system.security.claims;
//using system.text;
//using system.threading.tasks;

//namespace sh.website.controllers

//{
//    [route("api/[controller]")]
//    [apicontroller]
//    public class authenticatecontroller : controllerbase
//    {
//        private readonly usermanager<applicationuser> usermanager;
//        private readonly rolemanager<ıdentityrole> rolemanager;
//        private readonly ıconfiguration _configuration;

//        public authenticatecontroller(usermanager<applicationuser> usermanager, rolemanager<ıdentityrole> rolemanager, ıconfiguration configuration)
//        {
//            this.usermanager = usermanager;
//            this.rolemanager = rolemanager;
//            _configuration = configuration;
//        }

//        [httppost]
//        [route("login")]
//        public async task<ıactionresult> login([frombody] loginmodel model)
//        {
//            var user = await usermanager.findbynameasync(model.username);
//            if (user != null && await usermanager.checkpasswordasync(user, model.password))
//            {
//                var userroles = await usermanager.getrolesasync(user);

//                var authclaims = new list<claim>
//                {
//                    new claim(claimtypes.name, user.username),
//                    new claim(jwtregisteredclaimnames.jti, guid.newguid().tostring()),
//                };

//                foreach (var userrole in userroles)
//                {
//                    authclaims.add(new claim(claimtypes.role, userrole));
//                }

//                var authsigningkey = new symmetricsecuritykey(encoding.utf8.getbytes(_configuration["jwt:secret"]));

//                var token = new jwtsecuritytoken(
//                    issuer: _configuration["jwt:validıssuer"],
//                    audience: _configuration["jwt:validaudience"],
//                    expires: datetime.now.addhours(3),
//                    claims: authclaims,
//                    signingcredentials: new signingcredentials(authsigningkey, securityalgorithms.hmacsha256)
//                    );

//                return ok(new
//                {
//                    token = new jwtsecuritytokenhandler().writetoken(token),
//                    expiration = token.validto
//                });
//            }
//            return unauthorized();
//        }

//        [httppost]
//        [route("register")]
//        public async task<ıactionresult> register([frombody] registermodel model)
//        {
//            var userexists = await usermanager.findbynameasync(model.username);
//            if (userexists != null)
//                return statuscode(statuscodes.status500ınternalservererror, new response { status = "error", message = "user already exists!" });

//            applicationuser user = new applicationuser()
//            {
//                email = model.email,
//                securitystamp = guid.newguid().tostring(),
//                username = model.username
//            };
//            var result = await usermanager.createasync(user, model.password);
//            if (!result.succeeded)
//                return statuscode(statuscodes.status500ınternalservererror, new response { status = "error", message = "user creation failed! please check user details and try again." });

//            return ok(new response { status = "success", message = "user created successfully!" });
//        }

//        [httppost]
//        [route("register-admin")]
//        public async task<ıactionresult> registeradmin([frombody] registermodel model)
//        {
//            var userexists = await usermanager.findbynameasync(model.username);
//            if (userexists != null)
//                return statuscode(statuscodes.status500ınternalservererror, new response { status = "error", message = "user already exists!" });

//            applicationuser user = new applicationuser()
//            {
//                email = model.email,
//                securitystamp = guid.newguid().tostring(),
//                username = model.username
//            };
//            var result = await usermanager.createasync(user, model.password);
//            if (!result.succeeded)
//                return statuscode(statuscodes.status500ınternalservererror, new response { status = "error", message = "user creation failed! please check user details and try again." });

//            if (!await rolemanager.roleexistsasync(userroles.admin))
//                await rolemanager.createasync(new ıdentityrole(userroles.admin));
//            if (!await rolemanager.roleexistsasync(userroles.user))
//                await rolemanager.createasync(new ıdentityrole(userroles.user));

//            if (await rolemanager.roleexistsasync(userroles.admin))
//            {
//                await usermanager.addtoroleasync(user, userroles.admin);
//            }

//            return ok(new response { status = "success", message = "user created successfully!" });
//        }
//    }
//}