import {
  Button,
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardMeta,
  Image,
} from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';
import LoadingComponent from '../../../app/layout/LoadingComponent';

export default function ActivityDetails() {
  const { activtyStore } = useStore();
  const { selectedActivity: activity, openForm, cancelSelectActivity } = activtyStore;

  if (!activity) return <LoadingComponent />

  return (
    <Card fluid>
      <Image src={`/assets/categoryImages/${activity.category}.jpg`} />
      <CardContent>
        <CardHeader>{activity.title}</CardHeader>
        <CardMeta>
          <span>{activity.date}</span>
        </CardMeta>
        <CardDescription>{activity.description}</CardDescription>
      </CardContent>

      <CardContent extra>
        <Button.Group widths="2">
          <Button
            onClick={() => openForm(activity.id)}
            basic
            color="blue"
            content="Edit"
          />
          <Button
            onClick={cancelSelectActivity}
            basic
            color="grey"
            content="Cancel"
          />
        </Button.Group>
      </CardContent>
    </Card>
  );
}
