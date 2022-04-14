import { SyntheticEvent, useState } from "react";
import { Button, ListGroup } from "react-bootstrap";
import { Activity } from "../../../app/models/activity";

interface Props {
  activities: Activity[];
  selectActivity: (id: string) => void;
  deleteActivity: (id: string) => void;
  submitting: boolean;
}

export default function ActivityList({
  activities,
  selectActivity,
  deleteActivity,
  submitting,
}: Props) {
  const [target, setTarget] = useState("");

  function handleActivityDelete(
    event: SyntheticEvent<HTMLButtonElement>,
    id: string
  ) {
    setTarget(event.currentTarget.name);
    // if (confirm("Are you sure you want to delete this activity?")) {
    deleteActivity(id);
    // }
  }

  return (
    <ListGroup>
      {activities
        .sort((a, b) => (a.date > b.date ? 1 : -1))
        .map((activity) => (
          <ListGroup.Item key={activity.id}>
            {activity.title}
            <span>{activity.date?.toString()}</span>
            <span>{activity.description}</span>
            <span>{activity.city}</span>
            <span>{activity.venue}</span>
            <Button
              onClick={() => selectActivity(activity.id)}
              className="view-button"
            >
              View
            </Button>
            <Button
              name={activity.id}
              variant="danger"
              onClick={(event) => handleActivityDelete(event, activity.id)}
              className="view-button"
              disabled={submitting && target === activity.id}
            >
              Delete
            </Button>
            <label>{activity.category}</label>
          </ListGroup.Item>
        ))}
    </ListGroup>
  );
}
