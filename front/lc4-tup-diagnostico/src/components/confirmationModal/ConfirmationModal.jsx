import React from "react";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";

const ConfirmationModal = ({ show, handleClose, handleConfirm, title, body }) => {
  return (
    <Modal show={show} onHide={handleClose}>
      <Modal.Header closeButton>
        <Modal.Title>{title}</Modal.Title>
      </Modal.Header>
      <Modal.Body>{body}</Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={handleClose}>
          No
        </Button>
        <Button variant="danger" onClick={handleConfirm}>
          Sí
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ConfirmationModal;
