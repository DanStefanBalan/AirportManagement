import Joi from "@hapi/joi";

const airportSchema = Joi.object({
  name: Joi.string()
    .required()
    .min(4)
    .max(50)
    .label("Airport Name"),
  country: Joi.string()
    .required()
    .label("Country"),
  city: Joi.string()
    .required()
    .label("City")
});

export default airportSchema;
