import Joi from "@hapi/joi";

const aircraftSchema = Joi.object({
  flightId: Joi.string()
    .allow("")
    .label("Flight Id"),
  aircraftNumber: Joi.string()
    .required()
    .alphanum()
    .min(4)
    .max(10)
    .label("Aircraft Number"),
  countryOfRegistration: Joi.string()
    .required()
    .label("Country Of Registration"),
  numberOfPilots: Joi.number()
    .required()
    .min(2)
    .max(4)
    .label("Number Of Pilots"),
  manufacturer: Joi.string()
    .required()
    .alphanum()
    .min(6)
    .max(30)
    .label("Manufacturer"),
  model: Joi.string()
    .required()
    .alphanum()
    .min(6)
    .max(30)
    .label("Model"),
  numberOfSeats: Joi.number()
    .required()
    .label("Number Of Seats"),
  numberOfFlightAttendants: Joi.number()
    .required()
    .min(3)
    .max(12)
    .label("Number Of FlightAttendants")
});

export default aircraftSchema;
