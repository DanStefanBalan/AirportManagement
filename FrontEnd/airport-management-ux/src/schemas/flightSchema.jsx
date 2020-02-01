import Joi from "@hapi/joi";

const flightSchema = Joi.object({
  flightNumber: Joi.string()
    .required()
    .alphanum()
    .min(4)
    .max(10)
    .label("Flight Number"),
  aircraft: Joi.string()
    .required()
    .max(2)
    .label("Aircraft"),
  destination: Joi.string()
    .required()
    .label("Destination"),
  estimationHoursTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(24)
    .label("Estimation Time hours"),
  estimationMinutesTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(12)
    .label("Estimation Time minutes"),
  arrivalHoursTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(12)
    .label("Arrival Time hours"),
  arrivalMinutesTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(60)
    .label("Arrival Time hours"),
  departureHoursTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(12)
    .label("Departure Time hours"),
  departureMinutesTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(60)
    .label("Departure Time hours"),
  flightHoursTime: Joi.number()
    .required()
    .min(0)
    .max(12)
    .integer()
    .label("Flight Time hours"),
  flightMinutesTime: Joi.number()
    .required()
    .integer()
    .min(0)
    .max(60)
    .label("Flight Time hours"),
  status: Joi.string()
    .required()
    .label("Status"),
  gate: Joi.string()
    .required()
    .label("Gate"),
  airline: Joi.string()
    .required()
    .alphanum()
    .min(4)
    .max(20)
    .label("Airline")
});

export default flightSchema;
