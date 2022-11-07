namespace WebApi.Authorization;

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{ }

/*
The custom [AllowAnonymous] attribute is used to allow anonymous access to specified action methods of controllers that are decorated with the [Authorize] attribute. It's used in the users controller to allow anonymous access to the authenticate and refresh-token action methods. The custom authorize attribute below skips authorization if the action method is decorated with [AllowAnonymous].
*/