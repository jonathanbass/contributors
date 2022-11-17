import { Card, CardContent, CardHeader, Grid, Typography } from "@mui/material";
import { IContributer } from "./ContributersClient";

function Contributer({name, email, date}: IContributer) {
    return <Grid item xs={12} sm={6} md={4}>
        <Card elevation={3}>
            <CardHeader title={`Name: ${name}`} />
            <CardContent>
                <Typography>
                    Email: {email}
                </Typography>
                <Typography>
                    Date: {date}
                </Typography>
            </CardContent>
        </Card>
    </Grid>
}

export default Contributer;
