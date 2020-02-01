import Joi from "@hapi/joi";

const aircraftSchema = Joi.object({
  name: Joi.string()
    .required()
    .min(4)
    .max(20)
    .label("Airport Name"),
  country: Joi.string()
    .required()
    .label("Country"),
  city: Joi.string()
    .required()
    .label("City")
});

export default aircraftSchema;
