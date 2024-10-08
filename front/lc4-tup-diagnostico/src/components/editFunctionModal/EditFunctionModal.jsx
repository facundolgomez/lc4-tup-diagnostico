import React, { useState, useEffect } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import AlertSign from "../alertSign/AlertSign";

const EditFunctionModal = ({
  show,
  onHide,
  onSubmit,
  functionToEdit,
  peliculas,
}) => {
  const [fechaHora, setFechaHora] = useState("");
  const [precio, setPrecio] = useState("");
  const [peliculaId, setPeliculaId] = useState("");
  const [showAlert, setShowAlert] = useState(false);
  const [alertMessage, setAlertMessage] = useState("");

  useEffect(() => {
    if (functionToEdit) {
      const { date, precio, peliculaId } = functionToEdit;

      if (date) {
        const dateObject = new Date(date);
        const formattedDateTime = dateObject.toISOString().slice(0, 16);
        setFechaHora(formattedDateTime);
      }

      setPrecio(precio);
      setPeliculaId(peliculaId);
    }
  }, [functionToEdit]);

  const handleSubmit = () => {
    if (!fechaHora || !precio || !peliculaId) {
      setAlertMessage("Por favor complete todos los campos");
      setShowAlert(true);
      return;
    }

    const updatedFunction = {
      date: fechaHora + ":00.000Z",
      Precio: parseFloat(precio),
      PeliculaId: parseInt(peliculaId, 10),
    };

    console.log("Función actualizada:", updatedFunction);

    onSubmit(updatedFunction);

    onHide();

    setFechaHora("");
    setPrecio("");
    setPeliculaId("");

    window.location.reload();
  };

  return (
    <Modal show={show} onHide={onHide}>
      <Modal.Header closeButton>
        <Modal.Title>Editar función</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {showAlert && (
          <AlertSign
            message={alertMessage}
            variant="warning"
            duration={5000}
          />
        )}
        <Form>
          <Form.Group>
            <Form.Label>Fecha y Hora</Form.Label>
            <Form.Control
              type="datetime-local"
              value={fechaHora}
              onChange={(e) => {
                setFechaHora(e.target.value);
                setShowAlert(false);
              }}
              placeholder="Ingrese la fecha y hora"
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Precio</Form.Label>
            <Form.Control
              type="number"
              value={precio}
              onChange={(e) => {
                setPrecio(e.target.value);
                setShowAlert(false);
              }}
              placeholder="Ingrese el precio"
            />
          </Form.Group>
          <Form.Group>
            <Form.Label>Película</Form.Label>
            <Form.Control
              as="select"
              value={peliculaId}
              onChange={(e) => {
                setPeliculaId(e.target.value);
                setShowAlert(false);
              }}
            >
              <option value="">Seleccione la película</option>
              {peliculas &&
                peliculas.map((pelicula) => (
                  <option key={pelicula.id} value={pelicula.id}>
                    {pelicula.nombre}
                  </option>
                ))}
            </Form.Control>
          </Form.Group>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onHide}>
          Cerrar
        </Button>
        <Button variant="primary" onClick={handleSubmit}>
          Guardar cambios
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default EditFunctionModal;
