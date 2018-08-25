using System;
using Microsoft.AspNetCore.Mvc;
using Basics.PatternsAndPractices;
using Basics.DomainModelling;
using Basics.Mvc.ViewModels;
using Basics.Mvc.Controllers;
using Basics.UI;

namespace Basics.Mvc
{
    public static class ActionResultExtension
    {
        private const string DefaultTempDataAlertMessageKey = nameof(OrganizationViewModel.StatusMessage);

        public static IActionResult RedirectIfNot(this IActionResult instance,
              Func<bool> conditional,
              string message,
              AlertType messageType,
              string actionName,
              string controllerName,
              object routeValues)
        {
            if (instance.IsNotNull())
                return instance;

            if (conditional.IsNotNullOrDefault())
                throw new ArgumentNullException(nameof(conditional));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (message.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(message));

            return instance.RedirectIf(!conditional(), message, messageType, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectIf(this IActionResult instance,
            Func<bool> conditional,
            string message,
            AlertType messageType,
            string actionName,
            string controllerName,
            object routeValues)
        {
            if (instance.IsNotNull())
                return instance;

            if (conditional.IsNotNullOrDefault())
                throw new ArgumentNullException(nameof(conditional));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (message.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(message));

            return !conditional() ? null : instance.RedirectWithMessage(message, messageType, actionName, controllerName, routeValues);
        }


        public static IActionResult RedirectWithSuccessIfNot(
                 this IActionResult instance,
                 Func<bool> conditional,
                 string successMessage,
                 string actionName,
                 string controllerName = "",
                 object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (conditional.IsNullOrDefault())
                throw new ArgumentNullException(nameof(conditional));

            if (successMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(successMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!conditional())
                return null;

            return instance.RedirectWithSuccessIf(!conditional(), successMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithSuccessIf(
            this IActionResult instance,
            Func<bool> conditional,
            string successMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (conditional.IsNullOrDefault())
                throw new ArgumentNullException(nameof(conditional));

            if (successMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(successMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!conditional())
                return null;

            return instance.RedirectWithSuccess(successMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithErrorIfNot(
            this IActionResult instance,
            Func<bool> conditional,
            string errorMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (conditional.IsNullOrDefault())
                throw new ArgumentNullException(nameof(conditional));

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!conditional())
                return null;

            return instance.RedirectWithErrorIf(!conditional(), errorMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult View(
            this IActionResult instance,
            string viewName,
            object model)
        {
            return Controllers.Controller.Current.View(viewName, model);
        }

        public static IActionResult View(
            this IActionResult instance,
            object model)
        {
            return Controllers.Controller.Current.View(model);
        }

        public static IActionResult RedirectWithErrorIfActionFails(
            this IActionResult instance,
            Action tryThisAction,
            string errorMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (tryThisAction.IsNullOrDefault())
                throw new ArgumentNullException(nameof(tryThisAction));

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            try
            {
                tryThisAction();
            }
            catch
            {
                return instance.RedirectWithError(errorMessage, actionName, controllerName, routeValues);
            }

            return null;
            
        }

        public static IActionResult RedirectWithErrorIf(
            this IActionResult instance,
            Func<bool> conditional,
            string errorMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (conditional.IsNullOrDefault())
                throw new ArgumentNullException(nameof(conditional));

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!conditional())
                return null;

            return instance.RedirectWithError(errorMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectIfNot(this IActionResult instance,
            bool condition,
            string message,
            AlertType messageType,
            string actionName,
            string controllerName,
            object routeValues)
        {
            if (instance.IsNotNull())
                return instance;

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (message.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(message));

            return instance.RedirectIf(!condition, message, messageType, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectIf(this IActionResult instance,
            bool condition,
            string message,
            AlertType messageType,
            string actionName,
            string controllerName,
            object routeValues)
        {
            if (instance.IsNotNull())
                return instance;

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (message.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(message));

            return !condition ? null : instance.RedirectWithMessage(message, messageType, actionName, controllerName, routeValues);
        }


        public static IActionResult RedirectWithErrorIfEntityDoesNotExist<TEntity, TKey>(
            this IActionResult instance,
            TKey id,
            IRepository<TEntity, TKey> repository,
            out TEntity entity,
            string actionName,
            string controllerName = "",
            string errorMessage = "",
            object routeValues = null,
            string tempDataKey = "")
            where TEntity : IIdentifiable<TKey>
        {
            if (instance.IsNotNull())
            {
                entity = default(TEntity);
                return instance;
            }

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (repository.IsNull())
                throw new ArgumentNullException(nameof(repository));

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            return instance.RedirectWithErrorIfNot(repository.Exists(id, out entity), errorMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithSuccessIfNot(
            this IActionResult instance,
            bool condition,
            string successMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (condition.IsNullOrDefault())
                throw new ArgumentNullException(nameof(condition));

            if (successMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(successMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!condition)
                return null;

            return instance.RedirectWithSuccessIf(!condition, successMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithSuccessIf(
            this IActionResult instance,
            bool condition,
            string successMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (condition.IsNullOrDefault())
                throw new ArgumentNullException(nameof(condition));

            if (successMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(successMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!condition)
                return null;

            return instance.RedirectWithSuccess(successMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithErrorIfNot(
            this IActionResult instance,
            bool condition,
            string errorMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (condition.IsNullOrDefault())
                throw new ArgumentNullException(nameof(condition));

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!condition)
                return null;

            return instance.RedirectWithErrorIf(!condition, errorMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithErrorIf(
            this IActionResult instance,
            bool condition,
            string errorMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (condition.IsNullOrDefault())
                throw new ArgumentNullException(nameof(condition));

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            if (!condition)
                return null;

            return instance.RedirectWithError(errorMessage, actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithError(
            this IActionResult instance,
            string errorMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (errorMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(errorMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            instance.PutDangerMessageInTempData(DefaultTempDataAlertMessageKey, errorMessage);

            return new RedirectToActionResult(actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithSuccess(
            this IActionResult instance,
            string successMessage,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (successMessage.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(successMessage));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            instance.PutSuccessMessageInTempData(DefaultTempDataAlertMessageKey, successMessage);

            return new RedirectToActionResult(actionName, controllerName, routeValues);
        }

        public static IActionResult RedirectWithMessage(
            this IActionResult instance,
            string message,
            AlertType messageType,
            string actionName,
            string controllerName = "",
            object routeValues = null)
        {
            if (instance.IsNotNull())
                return instance;

            if (message.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(message));

            if (actionName.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(actionName));

            instance.PutMessageInTempData(DefaultTempDataAlertMessageKey, message, messageType);

            return new RedirectToActionResult(actionName, controllerName, routeValues);
        }

        private static void PutSuccessMessageInTempData(this IActionResult instance, string key, string message)
        {
            instance.PutMessageInTempData(key, message, AlertType.Success);
        }

        private static void PutDangerMessageInTempData(this IActionResult instance, string key, string message)
        {
            instance.PutMessageInTempData(key, message, AlertType.Danger);
        }

        private static void PutMessageInTempData(this IActionResult instance, string key, string message, AlertType type)
        {
            Controllers.Controller.Current.PutInTempData(key,
                new Alert(message, type, AlertBehaviour.Remain));
        }
    }
}
