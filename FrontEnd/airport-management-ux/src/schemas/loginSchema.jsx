import Joi from "@hapi/joi";
import data from "../resources/content.json";

const domains = [
  "com",
  "org",
  "edu",
  "gov",
  "uk",
  "net",
  "ca",
  "de",
  "jp",
  "fr",
  "au",
  "us",
  "ru",
  "ch",
  "it",
  "nl",
  "se",
  "no",
  "es",
  "mil",
  "ro"
];

export const registerSchema = Joi.object({
  username: Joi.string()
    .required()
    .alphanum()
    .min(5)
    .max(12)
    .messages({
      "string.empty": data.login.username.empty,
      "string.min": data.login.username.min,
      "string.max": data.login.username.max
    }),
  password: Joi.string()
    .required()
    .min(8)
    .messages({
      "string.empty": data.login.password.empty,
      "string.min": data.login.password.min
    }),
  passwordConfirmation: Joi.any()
    .valid(Joi.ref("password"))
    .messages({
      "any.only": data.login.passwordConfirmation.match
    }),
  email: Joi.string()
    .required()
    .email({ minDomainSegments: 2, tlds: { allow: domains } })
    .messages({
      "string.empty": data.login.email.empty,
      "string.email": data.login.email.valid
    })
});

export const loginSchema = Joi.object({
  username: Joi.string()
    .required()
    .alphanum()
    .min(5)
    .max(12)
    .messages({
      "string.empty": data.login.username.empty,
      "string.min": data.login.username.min,
      "string.max": data.login.username.max
    }),
  password: Joi.string()
    .required()
    .messages({
      "string.empty": data.login.password.empty
    })
});
